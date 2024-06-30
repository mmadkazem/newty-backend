namespace Reservation.Application.ReserveTimes.Commands.CreateReserveTime;

public sealed class CreateReserveTimeReceiptCommandHandler(IUnitOfWork uow)
    : IRequestHandler<CreateReserveTimeReceiptCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateReserveTimeReceiptCommandRequest request, CancellationToken cancellationToken)
    {

        var startDate = request.DateTime;
        var endDate = request.DateTime;
        int totalPrice = 0;
        List<ReserveItem> reserveItems = [];
        foreach (var artistService in request.ArtistServices)
        {
            var service = await _uow.Services.FindAsync(artistService.ServiceId, cancellationToken)
                ?? throw new ServiceNotFoundException();

            if (service.ArtistId != artistService.ArtistId)
            {
                throw new ArtistNotFoundException();
            }

            ReserveItem item = new()
            {
                StartDate = endDate,
                Service = service,
                Price = service.Price
            };

            endDate += service.Time.ToTimeSpan();
            totalPrice += service.Price;
            item.EndDate = endDate;

            reserveItems.Add(item);
        }

        #region Check Business Time Conflict
        var reserveTimesByBusinessId = await _uow.ReserveTimes.FindAsyncByBusinessId(request.BusinessId, cancellationToken);
        if (reserveTimesByBusinessId.Count != 0)
        {
            foreach (var time in reserveTimesByBusinessId)
            {
                foreach (var item in time.ReserveItems)
                {
                    if (request.ArtistServices.Any(a => a.ArtistId == item.Service.ArtistId))
                    {
                        if (item.StartDate <= endDate && startDate <= item.EndDate)
                        {
                            throw new BusinessTimeConflictException();
                        }
                    }
                }
            }
        }
        #endregion
        #region  Check User Time Conflict
        var reserveTimesByUserId = await _uow.ReserveTimes.FindAsyncByUserId(request.UserId, cancellationToken);
        if (reserveTimesByUserId.Any())
        {
            foreach (var time in reserveTimesByUserId)
            {
                foreach (var item in time.ReserveItems)
                {
                    if (item.StartDate <= endDate && startDate <= item.EndDate)
                    {
                        throw new UserTimeConflictException();
                    }
                }
            }
        }
        #endregion

        var user = await _uow.Users.FindAsync(request.UserId, cancellationToken)
            ?? throw new UserNotFoundException();
        ReserveTimeReceipt reserveTime = new()
        {
            TotalPrice = totalPrice,
            TotalStartDate = startDate,
            TotalEndDate = endDate,
            ReserveItems = reserveItems,
            User = user,
            BusinessReceiptId = request.BusinessId,
            State = ReserveState.Waiting
        };

        #region Create Transaction
        var userWallet = await _uow.Wallets.FindAsyncByUserId(request.UserId, cancellationToken)
            ?? throw new WalletNotFoundException();

        var businessWallet = await _uow.Wallets.FindAsyncByBusinessId(request.BusinessId, cancellationToken)
            ?? throw new WalletNotFoundException();

        Transaction transactionReceipt = new()
        {
            Amount = totalPrice,
            ReserveTime = reserveTime,
            Wallet = businessWallet,
            State = TransactionState.Waiting
        };

        Transaction transactionSender = new()
        {
            Amount = totalPrice,
            ReserveTime = reserveTime,
            Wallet = userWallet,
        };

        reserveTime.TransactionReceipt = transactionReceipt;
        reserveTime.TransactionSender = transactionSender;
        #endregion

        _uow.ReserveTimes.Add(reserveTime);

        await _uow.SaveChangeAsync(cancellationToken);

    }
}
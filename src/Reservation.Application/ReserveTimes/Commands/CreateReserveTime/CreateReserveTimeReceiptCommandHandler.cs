namespace Reservation.Application.ReserveTimes.Commands.CreateReserveTime;

public sealed class CreateReserveTimeReceiptCommandHandler(IUnitOfWork uow)
    : IRequestHandler<CreateReserveTimeReceiptCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateReserveTimeReceiptCommandRequest request, CancellationToken cancellationToken)
    {
        // var wallet = await _uow.Wallets.FindAsyncByUserId(request.UserId, cancellationToken)
        //     ?? throw new WalletNotFoundException();

        var startDate = request.DateTime;
        var endDate = request.DateTime;
        int totalPrice = 0;
        List<ReserveItem> reserveItems = [];
        foreach (var serviceId in request.Services)
        {
            var service = await _uow.Services.FindAsync(serviceId, cancellationToken)
                ?? throw new ServiceNotFoundException();

            if (!request.Artists.Any(a => a == service.ArtistId))
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
                    if (request.Artists.Any(a => a == item.Service.ArtistId))
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
        // if (wallet.Credit - totalPrice < 0)
        // {
        //     throw new BalanceInsufficientException();
        // }
        // wallet.Credit -= totalPrice;

        ReserveTimeReceipt reserveTime = new()
        {
            TotalPrice = totalPrice,
            TotalStartDate = startDate,
            TotalEndDate = endDate,
            ReserveItems = reserveItems,
            UserId = request.UserId,
            BusinessId = request.BusinessId,
            State = ReserveState.Waiting
        };

        // Transaction transaction = new()
        // {
        //     Amount = totalPrice,
        //     ReserveTime = reserveTime,
        //      Wallet = wallet
        // };

        _uow.ReserveTimes.Add(reserveTime);
        // _uow.Wallets.AddTransaction(transaction);

        await _uow.SaveChangeAsync(cancellationToken);
    }
}
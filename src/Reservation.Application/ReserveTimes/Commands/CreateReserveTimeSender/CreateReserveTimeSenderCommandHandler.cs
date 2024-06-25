namespace Reservation.Application.ReserveTimes.Commands.CreateReserveTimeSender;

public sealed class CreateReserveTimeSenderCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateReserveTimeSenderCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateReserveTimeSenderCommandRequest request, CancellationToken cancellationToken)
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
        var reserveTimesByBusinessReceiptId = await _uow.ReserveTimes.FindAsyncByBusinessId(request.BusinessReceiptId, cancellationToken);
        if (reserveTimesByBusinessReceiptId.Count != 0)
        {
            foreach (var time in reserveTimesByBusinessReceiptId)
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
        var reserveTimesByBusinessSenderId = await _uow.ReserveTimes.FindAsyncBusinessSenderId(request.BusinessSenderId, cancellationToken);
        if (reserveTimesByBusinessReceiptId.Count != 0)
        {
            foreach (var time in reserveTimesByBusinessReceiptId)
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

        ReserveTimeSender reserveTime = new()
        {
            TotalPrice = totalPrice,
            TotalStartDate = startDate,
            TotalEndDate = endDate,
            ReserveItems = reserveItems,
            BusinessSenderId = request.BusinessSenderId,
            BusinessReceiptId = request.BusinessReceiptId,
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

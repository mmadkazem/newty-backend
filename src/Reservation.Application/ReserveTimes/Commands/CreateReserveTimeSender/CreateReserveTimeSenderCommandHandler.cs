namespace Reservation.Application.ReserveTimes.Commands.CreateReserveTimeSender;

public sealed class CreateReserveTimeSenderCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateReserveTimeSenderCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateReserveTimeSenderCommandRequest request, CancellationToken cancellationToken)
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

        #region Check Business Receipt Time Conflict
        var reserveTimesByBusinessReceiptId = await _uow.ReserveTimes.FindAsyncByBusinessId(request.BusinessReceiptId, cancellationToken);
        if (reserveTimesByBusinessReceiptId.Count != 0)
        {
            foreach (var time in reserveTimesByBusinessReceiptId)
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
        #region  Check Business Sender Time Conflict
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

        ReserveTimeSender reserveTimeSender = new()
        {
            TotalPrice = totalPrice,
            TotalStartDate = startDate,
            TotalEndDate = endDate,
            ReserveItems = reserveItems,
            BusinessSenderId = request.BusinessSenderId,
            BusinessReceiptId = request.BusinessReceiptId,
            State = ReserveState.Waiting
        };

        var businessSender = await _uow.Businesses.FindAsync(request.BusinessSenderId, cancellationToken)
            ?? throw new BusinessesNotFoundException();


        ReserveTimeReceipt reserveTimeReceipt = new()
        {
            TotalPrice = totalPrice,
            TotalStartDate = startDate,
            TotalEndDate = endDate,
            ReserveItems = reserveItems,
            BusinessSender = businessSender,
            BusinessReceiptId = request.BusinessReceiptId,
            State = ReserveState.Waiting
        };

        #region Create Transaction
        var walletSender = await _uow.Wallets.FindAsyncByBusinessId(request.BusinessSenderId, cancellationToken)
            ?? throw new WalletNotFoundException();

        var walletReceipt = await _uow.Wallets.FindAsyncByBusinessId(request.BusinessReceiptId, cancellationToken)
            ?? throw new WalletNotFoundException();

        Transaction transactionSender = new()
        {
            Amount = totalPrice,
            Wallet = walletSender,
            Type = TransactionType.ReserveTimeSender
        };

        Transaction transactionReceipt = new()
        {
            Amount = totalPrice,
            Wallet = walletReceipt,
            Type = TransactionType.ReserveTimeReceipt,
            ReserveTime = reserveTimeReceipt
        };

        reserveTimeReceipt.TransactionReceipt = transactionReceipt;
        reserveTimeReceipt.TransactionSender = transactionSender;

        #endregion

        _uow.ReserveTimes.Add(reserveTimeSender);

        await _uow.SaveChangeAsync(cancellationToken);
    }
}

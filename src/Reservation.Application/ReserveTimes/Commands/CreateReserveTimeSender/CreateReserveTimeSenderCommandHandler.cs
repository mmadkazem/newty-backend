namespace Reservation.Application.ReserveTimes.Commands.CreateReserveTimeSender;



public sealed class CreateReserveTimeSenderCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateReserveTimeSenderCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateReserveTimeSenderCommandRequest request, CancellationToken cancellationToken)
    {
        var businessReceipt = await _uow.Businesses.FindAsync(request.BusinessReceiptId, cancellationToken)
            ?? throw new BusinessNotFoundException();

        var userReserveTime = new TimeSpan(request.DateTime.Hour, request.DateTime.Minute, request.DateTime.Second);

        if (!(businessReceipt.StartHoursOfWor <= userReserveTime &&
            userReserveTime <= businessReceipt.EndHoursOfWor))
        {
            throw new ThisTimeIsNotInTheWorkingTimeException();
        }

        if (businessReceipt.Holidays.Any(c => c == request.DateTime.DayOfWeek))
        {
            throw new BusinessHolidayException();
        }

        var startDate = request.DateTime;
        var endDate = request.DateTime;
        int totalPrice = 0;
        List<ReserveItem> reserveItems = [];
        foreach (var artistService in request.ArtistServices)
        {
            var service = await _uow.Services.FindAsyncIncludeArtist(artistService.ServiceId, cancellationToken)
                ?? throw new ServiceNotFoundException();

            if (service.Artist.Id != artistService.ArtistId)
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
                    if (request.ArtistServices.Any(a => a.ArtistId == item.Service.Artist.Id))
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
                        throw new BusinessTimeConflictException();
                    }
                }
            }
        }
        #endregion

        var businessSender = await _uow.Businesses.FindAsync(request.BusinessSenderId, cancellationToken)
            ?? throw new BusinessNotFoundException();

        ReserveTimeSender reserveTimeSender = new()
        {
            TotalPrice = totalPrice,
            TotalStartDate = startDate,
            TotalEndDate = endDate,
            ReserveItems = reserveItems,
            BusinessSender = businessSender,
            BusinessReceipt = businessReceipt,
            State = ReserveState.Waiting
        };

        ReserveTimeReceipt reserveTimeReceipt = new()
        {
            TotalPrice = totalPrice,
            TotalStartDate = startDate,
            TotalEndDate = endDate,
            ReserveItems = reserveItems,
            BusinessSender = businessSender,
            BusinessReceipt = businessReceipt,
            State = ReserveState.Waiting
        };

        var walletSender = await _uow.Wallets.FindAsyncByBusinessId(request.BusinessSenderId, cancellationToken)
            ?? throw new WalletNotFoundException();

        var walletReceipt = await _uow.Wallets.FindAsyncByBusinessId(request.BusinessReceiptId, cancellationToken)
            ?? throw new WalletNotFoundException();

        // block credit
        if (walletSender.Credit - totalPrice < 0)
        {
            throw new BalanceInsufficientException();
        }
        walletSender.Credit -= totalPrice;
        walletSender.BlockCredit += totalPrice;

        #region Create Transaction
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
        };

        reserveTimeReceipt.TransactionReceipt = transactionReceipt;
        reserveTimeReceipt.TransactionSender = transactionSender;

        #endregion

        _uow.ReserveTimes.Add(reserveTimeSender);

        await _uow.SaveChangeAsync(cancellationToken);
    }
}

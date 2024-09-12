namespace Reservation.Application.ReserveTimes.Commands.CreateReserveTime;

public sealed class CreateReserveTimeReceiptCommandHandler(IUnitOfWork uow)
    : IRequestHandler<CreateReserveTimeReceiptCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateReserveTimeReceiptCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsync(request.BusinessId, cancellationToken)
            ?? throw new BusinessNotFoundException();

        var userReserveTime = new TimeSpan(request.DateTime.Hour, request.DateTime.Minute, request.DateTime.Second);
        if (business.IsClose)
        {
            throw new BusinessClosedException();
        }
        if (!(business.StartHoursOfWor <= userReserveTime &&
            userReserveTime <= business.EndHoursOfWor))
        {
            throw new ThisTimeIsNotInTheWorkingTimeException();
        }
        if (business.Holidays.Any(c => c == request.DateTime.DayOfWeek))
        {
            throw new BusinessHolidayException();
        }

        var startDate = request.DateTime.ToLocalTime();
        var endDate = request.DateTime.ToLocalTime();
        int totalPrice = 0;
        List<ReserveItem> reserveItems = [];
        foreach (var artistService in request.ArtistServices)
        {
            var service = await _uow.Services.FindAsync(artistService.ServiceId, cancellationToken)
                ?? throw new ServiceNotFoundException();

            if (service.Artist.Id != artistService.ArtistId)
            {
                throw new ArtistNotFoundException();
            }

            ReserveItem item = new()
            {
                StartDate = endDate.ToLocalTime(),
                Service = service,
                Price = service.Price
            };

            endDate += service.Time.ToTimeSpan();
            totalPrice += service.Price;
            item.EndDate = endDate.ToLocalTime();

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
            BusinessReceipt = business,
            State = ReserveState.Waiting
        };

        var userWallet = await _uow.Wallets.FindAsyncByUserId(request.UserId, cancellationToken)
            ?? throw new WalletNotFoundException();

        var businessWallet = await _uow.Wallets.FindAsyncByBusinessId(request.BusinessId, cancellationToken)
            ?? throw new WalletNotFoundException();

        // block credit
        if (userWallet.Credit - totalPrice < 0)
        {
            throw new BalanceInsufficientException();
        }
        userWallet.Credit -= totalPrice;
        userWallet.BlockCredit += totalPrice;

        #region Create Transaction
        Transaction transactionReceipt = new()
        {
            Amount = totalPrice,
            Wallet = businessWallet,
            State = TransactionState.Waiting
        };

        Transaction transactionSender = new()
        {
            Amount = totalPrice,
            Wallet = userWallet,
            State = TransactionState.Waiting
        };

        reserveTime.TransactionReceipt = transactionReceipt;
        reserveTime.TransactionSender = transactionSender;
        #endregion

        _uow.ReserveTimes.Add(reserveTime);

        await _uow.SaveChangeAsync(cancellationToken);

    }
}
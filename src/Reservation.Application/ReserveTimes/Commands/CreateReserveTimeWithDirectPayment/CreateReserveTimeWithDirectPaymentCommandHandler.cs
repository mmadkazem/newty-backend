namespace Reservation.Application.ReserveTimes.Commands.CreateReserveTimeWithDirectPayment;




public sealed class CreateReserveTimeWithDirectPaymentCommandHandler(IUnitOfWork uow, IPaymentProvider paymentProvider, IPaymentUrlGeneratorService urlGenerator)
    : IRequestHandler<CreateReserveTimeWithDirectPaymentCommandRequest, string>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IPaymentProvider _paymentProvider = paymentProvider;
    private readonly IPaymentUrlGeneratorService _urlGenerator = urlGenerator;

    public async Task<string> Handle(CreateReserveTimeWithDirectPaymentCommandRequest request, CancellationToken cancellationToken)
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
            Id = Guid.NewGuid(),
            TotalPrice = totalPrice,
            TotalStartDate = startDate,
            TotalEndDate = endDate,
            ReserveItems = reserveItems,
            User = user,
            BusinessReceipt = business,
            State = ReserveState.Created,
            Type = PaymentType.Direct
        };

        var result = await _paymentProvider.RequestPaymentAsync(totalPrice, ReserveTimeSuccessMessage.Description + business.Name, _urlGenerator.GenerateReserveTimeRedirectUrl(reserveTime.Id))
            ?? throw new PaymentInvalidException();


        UserRequestPay userRequestPay = new()
        {
            Amount = totalPrice,
            User = user,
            Authority = result.Authority,
        };

        reserveTime.UserRequestPay = userRequestPay;

        var businessWallet = await _uow.Wallets.FindAsyncByBusinessId(request.BusinessId, cancellationToken)
            ?? throw new WalletNotFoundException();

        var userWallet = await _uow.Wallets.FindAsyncByUserId(request.UserId, cancellationToken)
            ?? throw new WalletNotFoundException();

        reserveTime.TransactionReceipt = new Transaction
        {
            Amount = totalPrice,
            Wallet = businessWallet,
            State = TransactionState.Created
        };

        reserveTime.TransactionSender = new Transaction
        {
            Amount = totalPrice,
            Wallet = userWallet,
            State = TransactionState.Created
        };

        _uow.ReserveTimes.Add(reserveTime);
        _uow.UserRequestPays.Add(userRequestPay);
        await _uow.SaveChangeAsync(cancellationToken);

        return result.PaymentUrl;
    }
}
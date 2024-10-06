namespace Reservation.Application.ReserveTimes.Commands.CreateReserveTime;

public sealed class CreateReserveTimeReceiptCommandHandler(IUnitOfWork uow)
    : IRequestHandler<CreateReserveTimeReceiptCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateReserveTimeReceiptCommandRequest request, CancellationToken cancellationToken)
    {
        // 1. Get business details and ensure it exists
        var business = await GetBusinessAsync(request.BusinessId, cancellationToken);

        // 2. Validate business is open, working hours, and not on holidays
        ValidateBusinessAvailability(business, request.DateTime);

        // 3. Create reserve items for each artist service in the request
        var reserveItems = await CreateReserveItemsAsync(request, cancellationToken);

        // 4. Check for time conflicts for both business and user reservations
        ValidateTimeConflicts(business, request.UserId, reserveItems.First().StartDate, reserveItems.Last().EndDate, request.ArtistServices, cancellationToken);

        // 5. Calculate total price for all services
        var totalPrice = reserveItems.Sum(item => item.Price);

        // 6. Find the user and create a reserve time receipt
        var user = await GetUserAsync(request.UserId, cancellationToken);
        var reserveTime = CreateReserveTimeReceipt(user, business, reserveItems, totalPrice);

        // 7. Handle wallet transactions and ensure the user has sufficient balance
        await HandleWalletTransactions(request.UserId, request.BusinessId, totalPrice, reserveTime, cancellationToken);

        // 8. Add the new reserve time to the database
        _uow.ReserveTimes.Add(reserveTime);

        // 9. Save changes in the database
        await _uow.SaveChangeAsync(cancellationToken);
    }

    // Helper method to retrieve the business, throwing an exception if it doesn't exist
    private async Task<Business> GetBusinessAsync(Guid businessId, CancellationToken cancellationToken)
    {
        return await _uow.Businesses.FindAsync(businessId, cancellationToken)
            ?? throw new BusinessNotFoundException();
    }

    // Validate if the business is open, working hours are correct, and the day is not a holiday
    private void ValidateBusinessAvailability(Business business, DateTime dateTime)
    {
        var userReserveTime = new TimeSpan(dateTime.Hour, dateTime.Minute, dateTime.Second);
        if (business.IsClose)
        {
            throw new BusinessClosedException();
        }
        if (!(business.StartHoursOfWor <= userReserveTime && userReserveTime <= business.EndHoursOfWor))
        {
            throw new ThisTimeIsNotInTheWorkingTimeException();
        }
        if (business.Holidays.Contains(dateTime.DayOfWeek))
        {
            throw new BusinessHolidayException();
        }
    }

    // Create reserve items for each service requested by the user
    private async Task<List<ReserveItem>> CreateReserveItemsAsync(CreateReserveTimeReceiptCommandRequest request, CancellationToken cancellationToken)
    {
        List<ReserveItem> reserveItems = new();
        DateTime endDate = request.DateTime;

        foreach (var artistService in request.ArtistServices)
        {
            // Fetch service details for the requested artist
            var service = await GetServiceForArtistAsync(artistService, cancellationToken);

            // Create a new reserve item with the service details and timing
            var reserveItem = new ReserveItem
            {
                StartDate = endDate,
                Service = service,
                Price = service.Price,
                EndDate = endDate.Add(service.Time.ToTimeSpan())
            };

            reserveItems.Add(reserveItem);
            endDate = reserveItem.EndDate;  // Update end date for the next service
        }

        return reserveItems;
    }

    // Fetch the service and ensure it belongs to the correct artist
    private async Task<BusinessService> GetServiceForArtistAsync(ArtistService artistService, CancellationToken cancellationToken)
    {
        var service = await _uow.Services.FindAsync(artistService.ServiceId, cancellationToken)
            ?? throw new ServiceNotFoundException();

        if (service.Artist.Id != artistService.ArtistId)
        {
            throw new ArtistNotFoundException();
        }

        return service;
    }

    // Validate that there are no time conflicts for the business and the user
    private void ValidateTimeConflicts(Business business, Guid userId, DateTime startDate, DateTime endDate, IEnumerable<ArtistService> artistServices, CancellationToken cancellationToken)
    {
        // Check for time conflicts with other reservations for the same business
        CheckBusinessTimeConflicts(business.Id, startDate, endDate, artistServices, cancellationToken);

        // Check for time conflicts with other reservations for the same user
        CheckUserTimeConflicts(userId, startDate, endDate, cancellationToken);
    }

    // Check if there are any conflicts with other reservations for the business
    private async void CheckBusinessTimeConflicts(Guid businessId, DateTime startDate, DateTime endDate, IEnumerable<ArtistService> artistServices, CancellationToken cancellationToken)
    {
        var businessReserveTimes = await _uow.ReserveTimes.FindAsyncByBusinessId(businessId, cancellationToken);

        foreach (var reserveTime in businessReserveTimes)
        {
            foreach (var item in reserveTime.ReserveItems)
            {
                if (artistServices.Any(a => a.ArtistId == item.Service.Artist.Id) && IsTimeConflict(item, startDate, endDate))
                {
                    throw new BusinessTimeConflictException();
                }
            }
        }
    }

    // Check if there are any conflicts with other reservations for the user
    private async void CheckUserTimeConflicts(Guid userId, DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
    {
        var userReserveTimes = await _uow.ReserveTimes.FindAsyncByUserId(userId, cancellationToken);

        foreach (var reserveTime in userReserveTimes)
        {
            foreach (var item in reserveTime.ReserveItems)
            {
                if (IsTimeConflict(item, startDate, endDate))
                {
                    throw new UserTimeConflictException();
                }
            }
        }
    }

    // Helper method to check if there is a time conflict between two reservations
    private bool IsTimeConflict(ReserveItem item, DateTime startDate, DateTime endDate)
    {
        return item.StartDate <= endDate && startDate <= item.EndDate;
    }

    // Create a reserve time receipt with all details and reserve items
    private ReserveTimeReceipt CreateReserveTimeReceipt(User user, Business business, List<ReserveItem> reserveItems, int totalPrice)
    {
        return new ReserveTimeReceipt
        {
            TotalPrice = totalPrice,
            TotalStartDate = reserveItems.First().StartDate,
            TotalEndDate = reserveItems.Last().EndDate,
            ReserveItems = reserveItems,
            User = user,
            BusinessReceipt = business,
            State = ReserveState.Waiting,
            Type = PaymentType.Wallet
        };
    }

    // Fetch user details and ensure the user exists
    private async Task<User> GetUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _uow.Users.FindAsync(userId, cancellationToken)
            ?? throw new UserNotFoundException();
    }

    // Handle the wallet transactions for both user and business, ensuring sufficient funds
    private async Task HandleWalletTransactions(Guid userId, Guid businessId, int totalPrice, ReserveTimeReceipt reserveTime, CancellationToken cancellationToken)
    {
        // Fetch user and business wallets
        var userWallet = await _uow.Wallets.FindAsyncByUserId(userId, cancellationToken)
            ?? throw new WalletNotFoundException();

        var businessWallet = await _uow.Wallets.FindAsyncByBusinessId(businessId, cancellationToken)
            ?? throw new WalletNotFoundException();

        // Ensure the user has enough balance to proceed
        if (userWallet.Credit < totalPrice)
        {
            throw new BalanceInsufficientException();
        }

        // Update wallet balances for the user
        userWallet.Credit -= totalPrice;
        userWallet.BlockCredit += totalPrice;

        // Create transactions for the reserve
        CreateTransactions(reserveTime, totalPrice, userWallet, businessWallet);
    }

    // Create the necessary transactions for both user and business wallets
    private void CreateTransactions(ReserveTimeReceipt reserveTime, int totalPrice, Wallet userWallet, Wallet businessWallet)
    {
        reserveTime.TransactionReceipt = new Transaction
        {
            Amount = totalPrice,
            Wallet = businessWallet,
            State = TransactionState.Waiting
        };

        reserveTime.TransactionSender = new Transaction
        {
            Amount = totalPrice,
            Wallet = userWallet,
            State = TransactionState.Waiting
        };
    }
}
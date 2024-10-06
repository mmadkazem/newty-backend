namespace Reservation.Test.Application.ReserveTimes;

public class CreateReserveTimeReceiptCommandHandlerTests
{
    private readonly IUnitOfWork _uowMock;
    private readonly IRequestHandler<CreateReserveTimeReceiptCommandRequest> _handler;

    public CreateReserveTimeReceiptCommandHandlerTests()
    {
        _uowMock = Substitute.For<IUnitOfWork>();
        _handler = new CreateReserveTimeReceiptCommandHandler(_uowMock);
    }
    [Fact]
    public async Task Handle_ShouldThrowBusinessNotFoundException_WhenBusinessDoesNotExist()
    {
        // Arrange
        var command = new CreateReserveTimeReceiptCommandRequest(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, new List<ArtistService>());
        _uowMock.Businesses.FindAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(default(Business));

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BusinessNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowBusinessClosedException_WhenBusinessIsClosed()
    {
        // Arrange
        var business = new Business { IsClose = true };
        var command = new CreateReserveTimeReceiptCommandRequest(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, new List<ArtistService>());
        _uowMock.Businesses.FindAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(business));

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BusinessClosedException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowThisTimeIsNotInTheWorkingTimeException_WhenTimeNotInWorkingHours()
    {
        // Arrange
        var business = new Business
        {
            IsClose = false,
            StartHoursOfWor = new TimeSpan(7, 0, 0),
            EndHoursOfWor = new TimeSpan(17, 0, 0)
        };
        var command = new CreateReserveTimeReceiptCommandRequest(Guid.NewGuid(), Guid.NewGuid(), new DateTime(2024, 10, 1, 18, 0, 0), new List<ArtistService>());
        _uowMock.Businesses.FindAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(business));

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ThisTimeIsNotInTheWorkingTimeException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowBusinessHolidayException_WhenDateIsOnBusinessHoliday()
    {
        // Arrange
        var business = new Business
        {
            IsClose = false,
            Holidays = [DayOfWeek.Monday, DayOfWeek.Saturday, DayOfWeek.Friday, DayOfWeek.Sunday, DayOfWeek.Thursday, DayOfWeek.Tuesday, DayOfWeek.Wednesday],
            StartHoursOfWor = new(0, 0, 0),
            EndHoursOfWor = new(24, 0, 0)
        };
        var command = new CreateReserveTimeReceiptCommandRequest(Guid.NewGuid(), Guid.NewGuid(), new DateTime(2024, 10, 1), []);
        _uowMock.Businesses.FindAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(business));

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BusinessHolidayException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowServiceNotFoundException_WhenServiceDoesNotExist()
    {
        // Arrange
        var business = new Business { IsClose = false, StartHoursOfWor = new(0, 0, 0), EndHoursOfWor = new(24, 0, 0) };
        var artistService = new ArtistService(Guid.NewGuid(), Guid.NewGuid());
        var command = new CreateReserveTimeReceiptCommandRequest(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, new List<ArtistService> { artistService });

        _uowMock.Businesses.FindAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(business));

        _uowMock.Services.FindAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(default(BusinessService));

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ServiceNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowArtistNotFoundException_WhenArtistDoesNotMatchService()
    {
        // Arrange
        var business = new Business { IsClose = false, StartHoursOfWor = new(0, 0, 0), EndHoursOfWor = new(24, 0, 0) };
        var artistService = new ArtistService(Guid.NewGuid(), Guid.NewGuid());
        var command = new CreateReserveTimeReceiptCommandRequest(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, new List<ArtistService> { artistService });

        var service = new BusinessService { Id = artistService.ServiceId, Artist = new Artist { Id = Guid.NewGuid() } };

        _uowMock.Businesses.FindAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(business));

        _uowMock.Services.FindAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(service));

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArtistNotFoundException>();
    }

    [Fact]
    public async Task Handle_ShouldThrowBalanceInsufficientException_WhenUserHasInsufficientBalance()
    {
        // Arrange
        var business = new Business { IsClose = false, StartHoursOfWor = new(0, 0, 0), EndHoursOfWor = new(24, 0, 0) };
        var artistService = new ArtistService(Guid.NewGuid(), Guid.NewGuid());
        var command = new CreateReserveTimeReceiptCommandRequest(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, [artistService]);
        var userWallet = new Wallet { Credit = 0 };
        var user = new User { Wallet = userWallet };
        var service = new BusinessService { Id = artistService.ServiceId, Artist = new Artist { Id = artistService.ArtistId }, Price = 100, Time = new TimeOnly(0, 30) };

        _uowMock.Businesses.FindAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(business));

        _uowMock.Users.FindAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(user));

        _uowMock.Services.FindAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(service));

        _uowMock.Wallets.FindAsyncByUserId(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(userWallet));

        _uowMock.Wallets.FindAsyncByBusinessId(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(new Wallet { Credit = 1000 }));
        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BalanceInsufficientException>();
    }

    [Fact]
    public async Task Handle_ShouldCompleteReservationSuccessfully_WhenAllConditionsMet()
    {
        // Arrange
        var business = new Business { IsClose = false, StartHoursOfWor = new(0, 0, 0), EndHoursOfWor = new(24, 0, 0) };
        var user = new User { };
        var artistService = new ArtistService(Guid.NewGuid(), Guid.NewGuid());
        var command = new CreateReserveTimeReceiptCommandRequest(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, [artistService]);
        var userWallet = new Wallet { Credit = 500 };
        var service = new BusinessService { Id = artistService.ServiceId, Artist = new Artist { Id = artistService.ArtistId }, Price = 100, Time = new TimeOnly(0, 30) };

        _uowMock.Businesses.FindAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(business));

        _uowMock.Users.FindAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(user));

        _uowMock.Services.FindAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(service));

        _uowMock.Wallets.FindAsyncByUserId(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(userWallet));

        _uowMock.Wallets.FindAsyncByBusinessId(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(new Wallet { Credit = 1000 }));

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().NotThrowAsync();
        userWallet.Credit.Should().Be(400);  // Ensure the user's credit is reduced correctly
    }

}

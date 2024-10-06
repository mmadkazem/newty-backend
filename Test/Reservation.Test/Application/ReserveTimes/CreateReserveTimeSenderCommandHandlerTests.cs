namespace Reservation.Test.Application.ReserveTimes;

public class CreateReserveTimeSenderCommandHandlerTests
{
    private readonly IUnitOfWork _uowMock;
    private readonly CreateReserveTimeSenderCommandHandler _handler;

    public CreateReserveTimeSenderCommandHandlerTests()
    {
        _uowMock = Substitute.For<IUnitOfWork>();
        _handler = new CreateReserveTimeSenderCommandHandler(_uowMock);
    }

    [Fact]
    public async Task Handle_BusinessReceiptNotFound_ThrowsUserNotFoundException()
    {
        // Arrange
        var request = new CreateReserveTimeSenderCommandRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.Now,
            []);

        _uowMock.Businesses.FindAsync(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns(default(Business));

        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BusinessNotFoundException>();
    }

    [Fact]
    public async Task Handle_TimeNotInWorkingHours_ThrowsThisTimeIsNotInTheWorkingTimeException()
    {
        // Arrange
        var request = new CreateReserveTimeSenderCommandRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.Now.AddHours(10), // Out of working hours
            []);

        var businessReceipt = new Business
        {
            StartHoursOfWor = new TimeSpan(9, 0, 0),
            EndHoursOfWor = new TimeSpan(17, 0, 0),
            Holidays = []
        };

        _uowMock.Businesses.FindAsync(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns(businessReceipt);

        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ThisTimeIsNotInTheWorkingTimeException>();
    }

    [Fact]
    public async Task Handle_BusinessHoliday_ThrowsBusinessHolidayException()
    {
        // Arrange
        var request = new CreateReserveTimeSenderCommandRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            new DateTime(2024, 10, 01),
            []);

        var businessReceipt = new Business
        {
            StartHoursOfWor = new TimeSpan(0, 0, 0),
            EndHoursOfWor = new TimeSpan(24, 0, 0),
            Holidays = [DayOfWeek.Tuesday]
        };

        _uowMock.Businesses.FindAsync(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns(businessReceipt);

        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BusinessHolidayException>();
    }

    [Fact]
    public async Task Handle_ServiceNotFound_ThrowsServiceNotFoundException()
    {
        // Arrange
        var request = new CreateReserveTimeSenderCommandRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.Now,
            [new(Guid.NewGuid(), Guid.NewGuid())]);

        var businessReceipt = new Business
        {
            StartHoursOfWor = new TimeSpan(0, 0, 0),
            EndHoursOfWor = new TimeSpan(24, 0, 0),
            Holidays = []
        };

        _uowMock.Businesses.FindAsync(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns(businessReceipt);
        _uowMock.Services.FindAsyncIncludeArtist(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(default(BusinessService));

        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ServiceNotFoundException>();
    }

    [Fact]
    public async Task Handle_ArtistNotFound_ThrowsArtistNotFoundException()
    {
        // Arrange
        var request = new CreateReserveTimeSenderCommandRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.Now,
            [new(Guid.NewGuid(), Guid.NewGuid())]);

        var businessReceipt = new Business
        {
            StartHoursOfWor = new TimeSpan(0, 0, 0),
            EndHoursOfWor = new TimeSpan(24, 0, 0),
            Holidays = []
        };

        var service = new BusinessService
        {
            Artist = new Artist { Id = Guid.NewGuid() } // Different artist ID
        };

        _uowMock.Businesses.FindAsync(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns(businessReceipt);

        _uowMock.Services.FindAsyncIncludeArtist(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(service);

        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArtistNotFoundException>();
    }

    [Fact]
    public async Task Handle_BusinessReceiptTimeConflict_ThrowsBusinessTimeConflictException()
    {
        // Arrange
        var request = new CreateReserveTimeSenderCommandRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.Now,
            [new(Guid.NewGuid(), Guid.NewGuid())]);

        var businessReceipt = new Business
        {
            StartHoursOfWor = new TimeSpan(0, 0, 0),
            EndHoursOfWor = new TimeSpan(24, 0, 0),
            Holidays = []
        };

        var service = new BusinessService
        {
            Artist = new Artist { Id = request.ArtistServices.First().ArtistId },
            Time = new(1, 0, 0),
            Price = 100
        };

        _uowMock.Businesses.FindAsync(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns(businessReceipt);

        _uowMock.Services.FindAsyncIncludeArtist(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(service);

        // Simulate an existing reservation that conflicts with the new reservation
        var existingReserveTime = new ReserveTimeReceipt
        {
            ReserveItems =
            [
                new ReserveItem
                {
                    StartDate = DateTime.Now.AddMinutes(30),
                    EndDate = DateTime.Now.AddHours(1),
                    Service = service
                }
            ],
        };

        _uowMock.ReserveTimes.FindAsyncByBusinessId(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns([existingReserveTime]);

        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BusinessTimeConflictException>();
    }

    [Fact]
    public async Task Handle_UserTimeConflict_ThrowsUserTimeConflictException()
    {
        // Arrange
        var request = new CreateReserveTimeSenderCommandRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.Now,
            [new(Guid.NewGuid(), Guid.NewGuid())]);

        var businessReceipt = new Business
        {
            StartHoursOfWor = new TimeSpan(0, 0, 0),
            EndHoursOfWor = new TimeSpan(24, 0, 0),
            Holidays = []
        };

        var service = new BusinessService
        {
            Artist = new Artist { Id = request.ArtistServices.First().ArtistId },
            Time = new(1, 0, 0),
            Price = 100
        };

        _uowMock.Businesses.FindAsync(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns(businessReceipt);

        _uowMock.Services.FindAsyncIncludeArtist(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(service);

        // Simulate an existing reservation that conflicts with the new reservation
        var existingReserveTimeReceipt = new ReserveTimeReceipt
        {
            ReserveItems =
            [
                new ReserveItem
                {
                    StartDate = DateTime.Now.AddMinutes(0),
                    EndDate = DateTime.Now.AddHours(0),
                    Service = service
                }
            ],
        };

        _uowMock.ReserveTimes.FindAsyncByBusinessId(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns([existingReserveTimeReceipt]);

        // Simulate an existing reservation that conflicts with the new reservation
        var existingReserveTimeSender = new ReserveTimeSender
        {
            ReserveItems =
            [
                new ReserveItem
                {
                    StartDate = DateTime.Now.AddMinutes(30),
                    EndDate = DateTime.Now.AddHours(1),
                    Service = service
                }
            ],
        };

        _uowMock.ReserveTimes.FindAsyncBusinessSenderId(request.BusinessSenderId, Arg.Any<CancellationToken>())
            .Returns([existingReserveTimeSender]);

        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BusinessTimeConflictException>();
    }

    [Fact]
    public async Task Handle_BusinessSenderNotFound_ThrowsBusinessNotFoundException()
    {
        // Arrange
        var request = new CreateReserveTimeSenderCommandRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.Now,
            []);

        var businessReceipt = new Business
        {
            StartHoursOfWor = new TimeSpan(0, 0, 0),
            EndHoursOfWor = new TimeSpan(24, 0, 0),
            Holidays = []
        };

        _uowMock.ReserveTimes.FindAsyncByBusinessId(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns([]);

        _uowMock.ReserveTimes.FindAsyncBusinessSenderId(request.BusinessSenderId, Arg.Any<CancellationToken>())
            .Returns([]);

        _uowMock.Businesses.FindAsync(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns(businessReceipt);

        _uowMock.Businesses.FindAsync(request.BusinessSenderId, Arg.Any<CancellationToken>())
            .Returns(default(Business));

        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BusinessNotFoundException>();
    }

    [Fact]
    public async Task Handle_WalletNotFound_ThrowsWalletNotFoundException()
    {
        // Arrange
        var request = new CreateReserveTimeSenderCommandRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.Now,
            []);

        var businessReceipt = new Business
        {
            StartHoursOfWor = new TimeSpan(0, 0, 0),
            EndHoursOfWor = new TimeSpan(24, 0, 0),
            Holidays = []
        };

        _uowMock.ReserveTimes.FindAsyncByBusinessId(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns([]);

        _uowMock.ReserveTimes.FindAsyncBusinessSenderId(request.BusinessSenderId, Arg.Any<CancellationToken>())
            .Returns([]);

        _uowMock.Businesses.FindAsync(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns(businessReceipt);

        _uowMock.Businesses.FindAsync(request.BusinessSenderId, Arg.Any<CancellationToken>())
            .Returns(new Business());

        _uowMock.Wallets.FindAsyncByBusinessId(request.BusinessSenderId, Arg.Any<CancellationToken>())
            .Returns(default(Wallet));

        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<WalletNotFoundException>();
    }

    [Fact]
    public async Task Handle_InsufficientBalance_ThrowsBalanceInsufficientException()
    {
        // Arrange
        var request = new CreateReserveTimeSenderCommandRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.Now,
            [new(Guid.NewGuid(), Guid.NewGuid())]);

        var businessReceipt = new Business
        {
            StartHoursOfWor = new TimeSpan(0, 0, 0),
            EndHoursOfWor = new TimeSpan(24, 0, 0),
            Holidays = []
        };

        var service = new BusinessService
        {
            Artist = new Artist { Id = request.ArtistServices.First().ArtistId },
            Time = new(1, 0, 0),
            Price = 100
        };

        _uowMock.ReserveTimes.FindAsyncByBusinessId(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns([]);

        _uowMock.ReserveTimes.FindAsyncBusinessSenderId(request.BusinessSenderId, Arg.Any<CancellationToken>())
            .Returns([]);

        _uowMock.Businesses.FindAsync(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns(businessReceipt);

        _uowMock.Businesses.FindAsync(request.BusinessSenderId, Arg.Any<CancellationToken>())
            .Returns(new Business());

        _uowMock.Services.FindAsyncIncludeArtist(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(service);

        _uowMock.Wallets.FindAsyncByBusinessId(request.BusinessSenderId, Arg.Any<CancellationToken>())
            .Returns(new Wallet { Credit = 0 });

        _uowMock.Wallets.FindAsyncByBusinessId(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns(new Wallet { Credit = 0 });

        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BalanceInsufficientException>();
    }

    [Fact]
    public async Task Handle_SuccessfulReservation_CreatesReservation()
    {
        // Arrange
        var request = new CreateReserveTimeSenderCommandRequest(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateTime.Now,
            [new(Guid.NewGuid(), Guid.NewGuid())]);

        var businessReceipt = new Business
        {
            StartHoursOfWor = new TimeSpan(0, 0, 0),
            EndHoursOfWor = new TimeSpan(24, 0, 0),
            Holidays = []
        };

        var service = new BusinessService
        {
            Artist = new Artist { Id = request.ArtistServices.First().ArtistId },
            Time = new(1, 0, 0),
            Price = 100
        };

        var walletSender = new Wallet { Credit = 200 };
        var walletReceipt = new Wallet { Credit = 200 };
        _uowMock.ReserveTimes.FindAsyncByBusinessId(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns([]);

        _uowMock.ReserveTimes.FindAsyncBusinessSenderId(request.BusinessSenderId, Arg.Any<CancellationToken>())
            .Returns([]);

        _uowMock.Businesses.FindAsync(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns(businessReceipt);

        _uowMock.Businesses.FindAsync(request.BusinessSenderId, Arg.Any<CancellationToken>())
            .Returns(new Business());

        _uowMock.Services.FindAsyncIncludeArtist(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(service);

        _uowMock.Wallets.FindAsyncByBusinessId(request.BusinessSenderId, Arg.Any<CancellationToken>())
            .Returns(walletSender);

        _uowMock.Wallets.FindAsyncByBusinessId(request.BusinessReceiptId, Arg.Any<CancellationToken>())
            .Returns(walletReceipt);

        // Act
        await _handler.Handle(request, CancellationToken.None);

        // Assert
        _uowMock.ReserveTimes.Received(1).Add(Arg.Any<ReserveTimeSender>());
        await _uowMock.Received(1).SaveChangeAsync(Arg.Any<CancellationToken>());
        walletSender.BlockCredit.Should().Be(100); // Check if the correct amount is blocked
    }
}

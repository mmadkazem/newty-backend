using Reservation.Application.Account.Queries.LoginInit;

namespace Reservation.Test.Application.ReserveTimes;



public class UpdateStateReserveTimeReceiptCommandHandlerTests
{
    private readonly IUnitOfWork _uowMock;
    private readonly IFinishReserveTimeJob _finishReserveTimeJobMock;
    private readonly UpdateStateReserveTimeReceiptCommandHandler _handler;

    public UpdateStateReserveTimeReceiptCommandHandlerTests()
    {
        _uowMock = Substitute.For<IUnitOfWork>();
        _finishReserveTimeJobMock = Substitute.For<IFinishReserveTimeJob>();
        _handler = new UpdateStateReserveTimeReceiptCommandHandler(_uowMock, _finishReserveTimeJobMock);
    }

    [Fact]
    public async Task Handle_Should_Throw_ReserveTimeNotFoundException_When_ReserveTime_Not_Found()
    {
        // Arrange
        var request = new UpdateStateReserveTimeReceiptCommandRequest(Guid.NewGuid(), ReserveState.Cancelled, "User", Guid.NewGuid());
        _uowMock.ReserveTimes.FindAsyncIncludeTransaction(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(default(ReserveTimeReceipt));

        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ReserveTimeNotFoundException>();
    }

    [Fact]
    public async Task Handle_Should_Throw_DotAccessReserveTimeException_When_User_Cannot_Access()
    {
        // Arrange
        var request = new UpdateStateReserveTimeReceiptCommandRequest(Guid.NewGuid(), ReserveState.Cancelled, Role.Business, Guid.NewGuid());
        var reserveTime = new ReserveTimeReceipt
        {
            User = new() { Id = Guid.NewGuid() },
            BusinessSender = new() { Id = request.CallId },
            BusinessReceipt = new() { Id = Guid.NewGuid() }
        };

        _uowMock.ReserveTimes.FindAsyncIncludeTransaction(request.Id, Arg.Any<CancellationToken>())
            .Returns(reserveTime);

        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<DotAccessReserveTimeException>();
    }

    [Fact]
    public async Task Handle_Should_Throw_UserNotAccessStateIsConfirmedException_When_User_Cannot_Access_To_Confirm_ReserveTime()
    {
        // Arrange
        var request = new UpdateStateReserveTimeReceiptCommandRequest(Guid.NewGuid(), ReserveState.Confirmed, "User", Guid.NewGuid());
        var reserveTime = new ReserveTimeReceipt
        {
            User = new User { Id = request.CallId },
            BusinessReceipt = new Business { Id = request.CallId, IsCancelReserveTime = true },
            TotalStartDate = DateTime.Now.AddDays(-2)
        };

        _uowMock.ReserveTimes.FindAsyncIncludeTransaction(request.Id, Arg.Any<CancellationToken>())
            .Returns(reserveTime);
        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<UserNotAccessStateIsConfirmedException>();
    }

    [Fact]
    public async Task Handle_Should_Throw_TimePassedCannotCancelException_When_Time_Already_Passed()
    {
        // Arrange
        var request = new UpdateStateReserveTimeReceiptCommandRequest(Guid.NewGuid(), ReserveState.Cancelled, "User", Guid.NewGuid());
        var reserveTime = new ReserveTimeReceipt
        {
            User = new User { Id = request.CallId },
            BusinessReceipt = new Business { Id = request.CallId, IsCancelReserveTime = true },
            TotalStartDate = DateTime.Now.AddDays(-2)
        };

        _uowMock.ReserveTimes.FindAsyncIncludeTransaction(request.Id, Arg.Any<CancellationToken>())
            .Returns(reserveTime);

        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<TimePassedCannotCancelException>();
    }

    [Fact]
    public async Task Handle_Should_Cancel_ReserveTime_Successfully()
    {
        // Arrange
        var request = new UpdateStateReserveTimeReceiptCommandRequest(Guid.NewGuid(), ReserveState.Cancelled, Role.User, Guid.NewGuid());
        var reserveTime = new ReserveTimeReceipt
        {
            User = new User { Id = request.CallId },
            BusinessReceipt = new Business { Id = request.CallId, IsCancelReserveTime = true },
            TotalStartDate = DateTime.Now.AddHours(25),
            TransactionReceipt = new() { State = TransactionState.Waiting },
            TransactionSender = new() { State = TransactionState.Waiting }
        };

        _uowMock.ReserveTimes.FindAsyncIncludeTransaction(request.Id, Arg.Any<CancellationToken>())
            .Returns(reserveTime);

        // Act
        var response = await _handler.Handle(request, CancellationToken.None);

        // Assert
        response.Message.Should().Be(ReserveTimeSuccessMessage.UpdatedCancelState);
        reserveTime.State.Should().Be(ReserveState.Cancelled);
        await _uowMock.Received(1).SaveChangeAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handle_Should_Throw_BalanceInsufficientException_When_User_Has_Insufficient_Balance()
    {
        // Arrange
        var request = new UpdateStateReserveTimeReceiptCommandRequest(Guid.NewGuid(), ReserveState.Confirmed, Role.Business, Guid.NewGuid());
        var reserveTime = new ReserveTimeReceipt
        {
            User = new() { Id = request.CallId },
            BusinessReceipt = new() { Id = request.CallId },
            TransactionReceipt = new() { Amount = 100 }
        };
        var userWallet = new Wallet { Credit = 50 };
        var businessWallet = new Wallet { Credit = 300 };

        _uowMock.ReserveTimes.FindAsyncIncludeTransaction(request.Id, Arg.Any<CancellationToken>())
            .Returns(reserveTime);

        _uowMock.Wallets.FindAsyncByUserId(reserveTime.User.Id, Arg.Any<CancellationToken>())
            .Returns(userWallet);

        _uowMock.Wallets.FindAsyncByBusinessId(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(businessWallet);
        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BalanceInsufficientException>();
    }

    [Fact]
    public async Task Handle_Should_Confirm_ReserveTime_Successfully()
    {
        // Arrange
        var request = new UpdateStateReserveTimeReceiptCommandRequest(Guid.NewGuid(), ReserveState.Confirmed, "Business", Guid.NewGuid());
        var reserveTime = new ReserveTimeReceipt
        {
            User = new User { Id = request.CallId },
            BusinessReceipt = new Business { Id = request.CallId },
            TransactionReceipt = new Transaction { Amount = 100 },
            TransactionSender = new Transaction { Amount = 100 },
            UserRequestPay = new()
        };
        var userWallet = new Wallet { Credit = 200 };
        var businessWallet = new Wallet { Credit = 300 };

        _uowMock.ReserveTimes.FindAsyncIncludeTransaction(request.Id, Arg.Any<CancellationToken>())
            .Returns(reserveTime);

        _uowMock.Wallets.FindAsyncByBusinessId(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(businessWallet);

        _uowMock.Wallets.FindAsyncByUserId(reserveTime.User.Id, Arg.Any<CancellationToken>())
            .Returns(userWallet);

        _finishReserveTimeJobMock.Execute(Arg.Any<Guid>(), DateTime.Now.AddDays(1));


        // Act
        var response = await _handler.Handle(request, CancellationToken.None);

        // Assert
        response.Message.Should().Be(ReserveTimeSuccessMessage.UpdatedConfirmState);
        reserveTime.State.Should().Be(ReserveState.Confirmed);
        userWallet.Credit.Should().Be(100);
        businessWallet.Credit.Should().Be(400);
        await _uowMock.Received(1).SaveChangeAsync(Arg.Any<CancellationToken>());
        _finishReserveTimeJobMock.Received(1).Execute(reserveTime.Id, reserveTime.TotalEndDate.AddMinutes(2));
    }
}

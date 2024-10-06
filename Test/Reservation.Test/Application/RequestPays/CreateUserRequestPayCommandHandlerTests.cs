namespace Reservation.Test.Application.RequestPays;



public class CreateUserRequestPayCommandHandlerTests
{
    private readonly IUnitOfWork _uowMock;
    private readonly IPaymentProvider _paymentProviderMock;
    private readonly IPaymentUrlGeneratorService _urlGeneratorMock;
    private readonly CreateUserRequestPayCommandHandler _handler;

    public CreateUserRequestPayCommandHandlerTests()
    {
        _uowMock = Substitute.For<IUnitOfWork>();
        _paymentProviderMock = Substitute.For<IPaymentProvider>();
        _urlGeneratorMock = Substitute.For<IPaymentUrlGeneratorService>();

        _handler = new CreateUserRequestPayCommandHandler(
            _uowMock,
            _paymentProviderMock,
            _urlGeneratorMock
        );
    }

    [Fact]
    public async Task Handle_ShouldReturnPaymentUrl_WhenPaymentIsSuccessful()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var request = new CreateUserRequestPayCommandRequest(userId, 1000);
        var token = new CancellationToken();

        var user = new User { Id = userId };
        var paymentResult = new PaymentResult("12345", "https://payment.com");

        _uowMock.Users.FindAsyncIncludeWallet(userId, token).Returns(user);
        _paymentProviderMock.RequestPaymentAsync(Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>())
            .Returns(paymentResult);

        _urlGeneratorMock.GenerateChargeWalletRedirectUrl(Arg.Any<Guid>(), WalletType.User)
            .Returns("https://redirect.com");

        // Act
        var result = await _handler.Handle(request, token);

        // Assert
        result.Should().Be("https://payment.com");
        _uowMock.UserRequestPays.Received(1).Add(Arg.Any<UserRequestPay>());
        await _uowMock.Received(1).SaveChangeAsync(token);
    }

    [Fact]
    public async Task Handle_ShouldThrowUserNotFoundException_WhenUserDoesNotExist()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var request = new CreateUserRequestPayCommandRequest(userId, 1000);
        var token = new CancellationToken();

        _uowMock.Users.FindAsyncIncludeWallet(userId, token).Returns(default(User));

        // Act
        Func<Task> act = async () => await _handler.Handle(request, token);

        // Assert
        await act.Should().ThrowAsync<UserNotFoundException>();

        _uowMock.UserRequestPays.DidNotReceive().Add(Arg.Any<UserRequestPay>());
        await _uowMock.DidNotReceive().SaveChangeAsync(token);
    }

    [Fact]
    public async Task Handle_ShouldThrowPaymentInvalidException_WhenPaymentFails()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var request = new CreateUserRequestPayCommandRequest(userId, 1000);
        var token = new CancellationToken();

        var user = new User { Id = userId };

        _uowMock.Users.FindAsyncIncludeWallet(userId, token).Returns(user);
        _paymentProviderMock.RequestPaymentAsync(Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>())
            .Returns(default(PaymentResult));

        _urlGeneratorMock.GenerateChargeWalletRedirectUrl(Arg.Any<Guid>(), WalletType.User)
            .Returns("https://redirect.com");

        // Act
        Func<Task> act = async () => await _handler.Handle(request, token);

        // Assert
        await act.Should().ThrowAsync<PaymentInvalidException>();

        _uowMock.UserRequestPays.DidNotReceive().Add(Arg.Any<UserRequestPay>());
        await _uowMock.DidNotReceive().SaveChangeAsync(token);
    }

    [Fact]
    public async Task Handle_ShouldSaveUserRequestPay_WhenPaymentIsSuccessful()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var request = new CreateUserRequestPayCommandRequest(userId, 1000);
        var token = new CancellationToken();

        var user = new User { Id = userId };
        var paymentResult = new PaymentResult("12345", "https://payment.com");

        _uowMock.Users.FindAsyncIncludeWallet(userId, token).Returns(user);
        _paymentProviderMock.RequestPaymentAsync(Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>())
            .Returns(paymentResult);

        _urlGeneratorMock.GenerateChargeWalletRedirectUrl(Arg.Any<Guid>(), WalletType.User)
            .Returns("https://redirect.com");

        // Act
        var result = await _handler.Handle(request, token);

        // Assert
        result.Should().Be("https://payment.com");

        _uowMock.UserRequestPays.Received(1).Add(Arg.Is<UserRequestPay>(x =>
            x.User == user &&
            x.Amount == request.Amount &&
            x.Authority == paymentResult.Authority));

        await _uowMock.Received(1).SaveChangeAsync(token);
    }
}

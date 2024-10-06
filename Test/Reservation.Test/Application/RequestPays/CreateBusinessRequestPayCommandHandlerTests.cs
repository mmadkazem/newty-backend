namespace Reservation.Test.Application.RequestPays;


public class CreateBusinessRequestPayCommandHandlerTests
{
    private readonly IUnitOfWork _uowMock;
    private readonly IPaymentProvider _paymentProviderMock;
    private readonly IPaymentUrlGeneratorService _urlGeneratorMock;
    private readonly CreateBusinessRequestPayCommandHandler _handler;

    public CreateBusinessRequestPayCommandHandlerTests()
    {
        _uowMock = Substitute.For<IUnitOfWork>();
        _paymentProviderMock = Substitute.For<IPaymentProvider>();
        _urlGeneratorMock = Substitute.For<IPaymentUrlGeneratorService>();

        _handler = new CreateBusinessRequestPayCommandHandler(
            _uowMock,
            _paymentProviderMock,
            _urlGeneratorMock
        );
    }

    [Fact]
    public async Task Handle_ShouldReturnPaymentUrl_WhenPaymentIsSuccessful()
    {
        // Arrange
        var businessId = Guid.NewGuid();
        var request = new CreateBusinessRequestPayCommandRequest(businessId, 1000);
        var token = new CancellationToken();

        var business = new Business { Id = businessId };
        var paymentResult = new PaymentResult("12345", "https://payment.com");

        _uowMock.Businesses.FindAsyncIncludeWallet(businessId, token).Returns(business);
        _paymentProviderMock.RequestPaymentAsync(Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>())
            .Returns(paymentResult);

        _urlGeneratorMock.GenerateChargeWalletRedirectUrl(Arg.Any<Guid>(), WalletType.Business)
            .Returns("https://redirect.com");

        // Act
        var result = await _handler.Handle(request, token);

        // Assert
        result.Should().Be("https://payment.com");
        _uowMock.BusinessRequestPays.Received(1).Add(Arg.Any<BusinessRequestPay>());
        await _uowMock.Received(1).SaveChangeAsync(token);
    }
    [Fact]
    public async Task Handle_ShouldThrowBusinessNotFoundException_WhenBusinessDoesNotExist()
    {
        // Arrange
        var businessId = Guid.NewGuid();
        var request = new CreateBusinessRequestPayCommandRequest(businessId, 1000);
        var token = new CancellationToken();

        _uowMock.Businesses.FindAsyncIncludeWallet(businessId, token).Returns(default(Business));

        // Act
        Func<Task> act = async () => await _handler.Handle(request, token);

        // Assert
        await act.Should().ThrowAsync<BusinessNotFoundException>();

        _uowMock.BusinessRequestPays.DidNotReceive().Add(Arg.Any<BusinessRequestPay>());
        await _uowMock.DidNotReceive().SaveChangeAsync(token);
    }
    [Fact]
    public async Task Handle_ShouldThrowPaymentInvalidException_WhenPaymentFails()
    {
        // Arrange
        var businessId = Guid.NewGuid();
        var request = new CreateBusinessRequestPayCommandRequest(businessId, 1000);
        var token = new CancellationToken();

        var business = new Business { Id = businessId };

        _uowMock.Businesses.FindAsyncIncludeWallet(businessId, token).Returns(business);
        _paymentProviderMock.RequestPaymentAsync(Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>())
            .Returns(default(PaymentResult));

        _urlGeneratorMock.GenerateChargeWalletRedirectUrl(Arg.Any<Guid>(), WalletType.Business)
            .Returns("https://redirect.com");

        // Act
        Func<Task> act = async () => await _handler.Handle(request, token);

        // Assert
        await act.Should().ThrowAsync<PaymentInvalidException>();

        _uowMock.BusinessRequestPays.DidNotReceive().Add(Arg.Any<BusinessRequestPay>());
        await _uowMock.DidNotReceive().SaveChangeAsync(token);
    }
    [Fact]
    public async Task Handle_ShouldThrowException_WhenUrlGenerationFails()
    {
        // Arrange
        var businessId = Guid.NewGuid();
        var request = new CreateBusinessRequestPayCommandRequest(businessId, 1000);
        var token = new CancellationToken();

        var business = new Business { Id = businessId };

        _uowMock.Businesses.FindAsyncIncludeWallet(businessId, token).Returns(business);

        _paymentProviderMock.RequestPaymentAsync(Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>())
            .Returns(default(PaymentResult));

        _urlGeneratorMock.GenerateChargeWalletRedirectUrl(Arg.Any<Guid>(), WalletType.Business)
            .Returns(default(string));

        // Act
        Func<Task> act = async () => await _handler.Handle(request, token);

        // Assert
        await act.Should().ThrowAsync<PaymentInvalidException>();
    }
    [Fact]
    public async Task Handle_ShouldSaveBusinessRequestPay_WhenPaymentIsSuccessful()
    {
        // Arrange
        var businessId = Guid.NewGuid();
        var request = new CreateBusinessRequestPayCommandRequest(businessId, 1000);
        var token = new CancellationToken();

        var business = new Business { Id = businessId };
        var paymentResult = new PaymentResult("12345", "https://payment.com");

        _uowMock.Businesses.FindAsyncIncludeWallet(businessId, token).Returns(business);
        _paymentProviderMock.RequestPaymentAsync(Arg.Any<int>(), Arg.Any<string>(), Arg.Any<string>())
            .Returns(paymentResult);

        _urlGeneratorMock.GenerateChargeWalletRedirectUrl(Arg.Any<Guid>(), WalletType.Business)
            .Returns("https://redirect.com");

        // Act
        var result = await _handler.Handle(request, token);

        // Assert
        result.Should().Be("https://payment.com");

        _uowMock.BusinessRequestPays.Received(1).Add(Arg.Is<BusinessRequestPay>(x =>
            x.Business == business &&
            x.Amount == request.Amount &&
            x.Authorizy == paymentResult.Authority));

        await _uowMock.Received(1).SaveChangeAsync(token);
    }
}

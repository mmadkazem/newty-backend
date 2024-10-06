namespace Reservation.Application.Finances.UserRequestPays.Commands.CreateUserRequestPay;



public sealed class CreateUserRequestPayCommandHandler(IUnitOfWork uow, IPaymentProvider paymentProvider, IPaymentUrlGeneratorService urlGenerator)
    : IRequestHandler<CreateUserRequestPayCommandRequest, string>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IPaymentProvider _paymentProvider = paymentProvider;
    private readonly IPaymentUrlGeneratorService _urlGenerator = urlGenerator;


    public async Task<string> Handle(CreateUserRequestPayCommandRequest request, CancellationToken token)
    {
        // Fetch user and ensure it exists
        var user = await GetUserWithWalletAsync(request.UserId, token);

        // Create a unique ID for the payment request
        var requestPayId = Guid.NewGuid();

        // Request payment and handle potential failure
        var paymentResult = await RequestPaymentAsync(request.Amount, requestPayId);

        // Save the payment request details to the database
        await SaveUserRequestPayAsync(user, requestPayId, request.Amount, paymentResult.Authority, token);

        // Return the payment URL
        return paymentResult.PaymentUrl;
    }

    private async Task<User> GetUserWithWalletAsync(Guid userId, CancellationToken token)
    {
        var user = await _uow.Users.FindAsyncIncludeWallet(userId, token)
            ?? throw new UserNotFoundException();

        return user;
    }

    private async Task<PaymentResult> RequestPaymentAsync(int amount, Guid requestPayId)
    {
        var result = await _paymentProvider.RequestPaymentAsync(
            amount,
            "Payment for user",
            _urlGenerator.GenerateChargeWalletRedirectUrl(requestPayId, WalletType.User)
        ) ?? throw new PaymentInvalidException();

        return result;
    }

    private async Task SaveUserRequestPayAsync(User user, Guid requestPayId, int amount, string authority, CancellationToken token)
    {
        var userRequestPay = new UserRequestPay
        {
            Id = requestPayId,
            Amount = amount,
            User = user,
            Authority = authority
        };

        _uow.UserRequestPays.Add(userRequestPay);
        await _uow.SaveChangeAsync(token);
    }
}
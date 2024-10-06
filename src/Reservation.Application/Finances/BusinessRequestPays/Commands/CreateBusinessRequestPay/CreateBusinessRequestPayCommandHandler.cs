namespace Reservation.Application.Finances.BusinessRequestPays.Commands.CreateBusinessRequestPay;

public class CreateBusinessRequestPayCommandHandler
(
    IUnitOfWork uow,
    IPaymentProvider paymentProvider,
    IPaymentUrlGeneratorService urlGenerator
) : IRequestHandler<CreateBusinessRequestPayCommandRequest, string>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IPaymentProvider _paymentProvider = paymentProvider;
    private readonly IPaymentUrlGeneratorService _urlGenerator = urlGenerator;

    public async Task<string> Handle(CreateBusinessRequestPayCommandRequest request, CancellationToken token)
    {
        // Fetch business and ensure it exists
        var business = await GetBusinessWithWalletAsync(request.BusinessId, token);

        // Create a unique ID for the payment request
        var requestPayId = Guid.NewGuid();

        // Request payment and handle potential failure
        var paymentResult = await RequestPaymentAsync(request.Amount, requestPayId);

        // Save the payment request details to the database
        await SaveBusinessRequestPayAsync(business, requestPayId, request.Amount, paymentResult.Authority, token);

        // Return the payment URL
        return paymentResult.PaymentUrl;
    }

    private async Task<Business> GetBusinessWithWalletAsync(Guid businessId, CancellationToken token)
    {
        var business = await _uow.Businesses.FindAsyncIncludeWallet(businessId, token)
            ?? throw new BusinessNotFoundException();

        return business;
    }

    private async Task<PaymentResult> RequestPaymentAsync(int amount, Guid requestPayId)
    {
        var result = await _paymentProvider.RequestPaymentAsync(
            amount,
            Message.Description,
            _urlGenerator.GenerateChargeWalletRedirectUrl(requestPayId, WalletType.Business)
        ) ?? throw new PaymentInvalidException();

        return result;
    }

    private async Task SaveBusinessRequestPayAsync(Business business, Guid requestPayId, int amount, string authority, CancellationToken token)
    {
        var businessRequestPay = new BusinessRequestPay
        {
            Id = requestPayId,
            Amount = amount,
            Business = business,
            Authorizy = authority
        };

        _uow.BusinessRequestPays.Add(businessRequestPay);
        await _uow.SaveChangeAsync(token);
    }

}
namespace Reservation.Infrastructure.ExternalServices.Job;


public sealed class SendSMSToUserVIPJob(IBackgroundJobClient client, IServiceScopeFactory scopeFactory)
    : ISendSMSToUserVIPJob
{
    private readonly IBackgroundJobClient _client = client;
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;

    public void Send(Guid businessId, DateTime sendDate, string message, List<string> receptorNumbers)
    {
        _client.Enqueue<SendSMSToUserVIPService>(s => s.Execute(businessId, sendDate, message, receptorNumbers, _scopeFactory));
    }
}

public sealed class SendSMSToUserVIPService
{
    public void Execute(Guid businessId, DateTime sendDate, string message, List<string> receptorNumbers, IServiceScopeFactory _scopeFactory)
    {
        using var serviceScope = _scopeFactory.CreateScope();
        using var _context = serviceScope.ServiceProvider.GetService<NewtyDbContext>();
        var _option = serviceScope.ServiceProvider.GetService<IOptions<SMSProviderOption>>();

        var api = new KavenegarApi(_option.Value.Key);
        api.Send(_option.Value.Sender, receptorNumbers, message, MessageType.MobileMemory, sendDate);
    }
}

public sealed class SMSProviderOption
{
    public string Key { get; set; }
    public string Sender { get; set; }
}
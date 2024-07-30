namespace Reservation.Infrastructure.ExternalServices.Job;


public sealed class SendSMSToUserVIPJob(IBackgroundJobClient client, IServiceScopeFactory scopeFactory)
    : ISendSMSToUserVIPJob
{
    private readonly IBackgroundJobClient _client = client;
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;

    public void Send(Guid businessId, DateTime sendDate, string message)
    {
        _client.Enqueue<SendSMSToUserVIPService>(s => s.Execute(businessId, sendDate, message, _scopeFactory));
    }
}

public sealed class SendSMSToUserVIPService
{
    public void Execute(Guid businessId, DateTime sendDate, string message, IServiceScopeFactory _scopeFactory)
    {
        using var serviceScope = _scopeFactory.CreateScope();
        using var _context = serviceScope.ServiceProvider.GetService<ReservationDbContext>();
        var _option = serviceScope.ServiceProvider.GetService<IOptions<SMSProviderOption>>();
        var count = 0;
        List<string> receptorNumber = [];
        while (true)
        {
            var userVIPs = _context.UsersVIP.AsQueryable()
                                    .Select(u => u.User.PhoneNumber)
                                    .Skip((count - 1) * 25)
                                    .Take(25)
                                    .ToList();
            if (userVIPs.Count == 0)
            {
                break;
            }
            count++;
            receptorNumber.AddRange(userVIPs);
        }
        var api = new KavenegarApi(_option.Value.Key);
        api.Send(_option.Value.Sender, receptorNumber, message, MessageType.MobileMemory, sendDate);
    }
}

public sealed class SMSProviderOption
{
    public string Key { get; set; }
    public string Sender { get; set; }
}
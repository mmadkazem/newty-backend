namespace Reservation.Infrastructure.ExternalServices.SmsProvider;


public class KavenegarProvider(IOptions<SmsProviderOption> options) : ISmsProvider
{
    private readonly IOptions<SmsProviderOption> _options = options;

    public async Task SendLookup(string receptor, string token, string token2 = null, string token3 = null)
    {
        try
        {
            var api = new KavenegarApi(_options.Value.Key);
            await api.VerifyLookup(receptor, token, _options.Value.Template);
        }

        catch (ApiException ex)
        {
            throw new Exception(ex.Message);
        }
        catch (HttpException ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public Task SendSms(string mobile, string fullName)
    {
        throw new NotImplementedException();
    }
}
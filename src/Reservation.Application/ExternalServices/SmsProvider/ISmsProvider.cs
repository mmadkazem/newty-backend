namespace Reservation.Application.ExternalServices.SmsProvider;

public interface ISmsProvider
{
    Task SendSms(string mobile, string fullName);

    Task SendLookup(string receptor,
    string token, string? token2 = null, string? token3 = null);

}
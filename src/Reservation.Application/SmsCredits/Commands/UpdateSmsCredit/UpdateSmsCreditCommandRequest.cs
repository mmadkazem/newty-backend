namespace Reservation.Application.SmsCredits.Commands.UpdateSmsCredit;


public record UpdateSmsCreditCommandRequest(Guid BusinessId, int Count) : IRequest
{
    public static UpdateSmsCreditCommandRequest Create(Guid businessId, int count)
        => new(businessId, count);
}

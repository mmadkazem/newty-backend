namespace Reservation.Application.SmsCredits.Commands.CreateSmsCredit;


public record CreateSmsCreditCommandRequest( Guid BusinessId, int Count) : IRequest
{
    public static CreateSmsCreditCommandRequest Create( Guid businessId, int count)
        => new(businessId, count);
}

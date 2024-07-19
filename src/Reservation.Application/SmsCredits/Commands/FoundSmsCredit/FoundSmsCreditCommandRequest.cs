namespace Reservation.Application.SmsCredits.Commands.FoundSmsCredit;


public record FoundSmsCreditCommandRequest(Guid BusinessId, Guid SMSPlanId) : IRequest
{
    public static FoundSmsCreditCommandRequest Create(Guid businessId, Guid smsPlanId)
        => new(businessId, smsPlanId);
}

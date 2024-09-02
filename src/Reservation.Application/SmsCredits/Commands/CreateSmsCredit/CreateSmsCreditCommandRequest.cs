namespace Reservation.Application.SmsCredits.Commands.CreateSmsCredit;


public record CreateSmsCreditCommandRequest(Guid BusinessId) : IRequest<string>;

namespace Reservation.Application.Businesses.Commands.SendSMSUserVIP;


public sealed record SendSMSUserVIPCommandRequest(Guid BusinessId, Guid SmsTemplateId, DateTime SendDate, List<string> PhoneNumebrs) : IRequest;

public sealed class SendSMSUserVIPCommandHandler(IUnitOfWork uow, ISendSMSToUserVIPJob sendSMSToUserVIPJob) : IRequestHandler<SendSMSUserVIPCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ISendSMSToUserVIPJob _sendSMSToUserVIPJob = sendSMSToUserVIPJob;

    public async Task Handle(SendSMSUserVIPCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsync(request.BusinessId, cancellationToken)
            ?? throw new BusinessNotFoundException();

        var template = await _uow.SmsTemplates.FindAsync(request.SmsTemplateId, cancellationToken)
            ?? throw new SmsTemplateNotFoundException();

        _sendSMSToUserVIPJob.Send(business.Id, request.SendDate, template.Description, request.PhoneNumebrs);
    }
}
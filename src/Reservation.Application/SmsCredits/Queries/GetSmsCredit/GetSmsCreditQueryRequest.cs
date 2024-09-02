
namespace Reservation.Application.SmsCredits.Queries.GetSmsCredit;


public record GetSmsCreditQueryRequest(Guid BusinessId) : IRequest<IResponse>;

public record GetSmsCreditQueryResponse(int Count) : IResponse;

public class GetSmsCreditQueryHandler(IUnitOfWork uow) : IRequestHandler<GetSmsCreditQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetSmsCreditQueryRequest request, CancellationToken cancellationToken)
        => await _uow.SmsCredits.Get(request.BusinessId, cancellationToken)
            ?? throw new SmsCreditNotFoundException();
}
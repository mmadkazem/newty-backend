
namespace Reservation.Application.SmsCredits.Queries.GetSmsCredit;


public record GetSmsCreditQueryRequest(Guid BusinessId) : IRequest<IResponse>;

public record GetSmsCreditQueryResponse(int Count) : IResponse;

public class GetSmsCreditQueryHandler : IRequestHandler<GetSmsCreditQueryRequest, IResponse>
{
    // private readonly IUnitOfWork _uow;
    public Task<IResponse> Handle(GetSmsCreditQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
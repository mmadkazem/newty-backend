namespace Reservation.Application.Businesses.Queries.GetNormalUsers;


public sealed record GetNormalUserQueryRequest(Guid BusinessId, int Page, int Size)
    : IRequest<Response>;

public sealed record GetNormalUserQueryResponse(Guid Id, string Name, string PhoneNumber) : IResponse;

public sealed class GetNormalUserQueryHandler(IUnitOfWork uow) : IRequestHandler<GetNormalUserQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetNormalUserQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.Businesses.GetNormalUser(request.BusinessId, request.Page, request.Size, cancellationToken);
        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}



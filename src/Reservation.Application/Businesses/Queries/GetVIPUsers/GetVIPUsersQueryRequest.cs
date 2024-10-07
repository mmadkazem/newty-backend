namespace Reservation.Application.Businesses.Queries.GetVIPUsers;


public sealed record GetVIPUsersQueryRequest(Guid BusinessId, int Page, int Size) : IRequest<Response>;

public sealed record GetVIPUserQueryResponse(Guid Id, string Name, string PhoneNumber) : IResponse;
public sealed class GetVIPUsersQueryHandler(IUnitOfWork uow) : IRequestHandler<GetVIPUsersQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetVIPUsersQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.Businesses.GetVIPUser(request.BusinessId, request.Page, request.Size, cancellationToken);
        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}
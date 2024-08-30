namespace Reservation.Application.Finances.UserRequestPays.Queries.GetUserRequestPays;

public class GetUserRequestPaysQueryHandler(IUnitOfWork uow) : IRequestHandler<GetUserRequestPaysQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetUserRequestPaysQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.UserRequestPays.Gets(request.Page, request.Size, request.UserId, cancellationToken);

        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}
namespace Reservation.Application.Finances.UserRequestPays.Queries.GetUserRequestPays;

public class GetUserRequestPaysQueryHandler(IUnitOfWork uow) : IRequestHandler<GetUserRequestPaysQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetUserRequestPaysQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.UserRequestPays.Gets(request.Page, request.UserId, cancellationToken);

        if (!responses.Any())
        {
            throw new UserRequestPayNotFoundException();
        }

        return responses;
    }
}
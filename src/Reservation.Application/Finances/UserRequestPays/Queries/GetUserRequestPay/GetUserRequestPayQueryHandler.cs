
namespace Reservation.Application.Finances.UserRequestPays.Queries.GetUserRequestPay;

public class GetUserRequestPayQueryHandler(IUnitOfWork uow) : IRequestHandler<GetUserRequestPayQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetUserRequestPayQueryRequest request, CancellationToken cancellationToken)
        => await _uow.UserRequestPays.Get(request.Id, request.UserId, cancellationToken)
            ?? throw new UserRequestPayNotFoundException();
}
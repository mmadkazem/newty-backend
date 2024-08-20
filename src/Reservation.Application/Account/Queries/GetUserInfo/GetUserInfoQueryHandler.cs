namespace Reservation.Application.Account.Queries.GetUserInfo;

public sealed class GetUserInfoQueryHandler(IUnitOfWork uow)
    : IRequestHandler<GetUserInfoQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetUserInfoQueryRequest request, CancellationToken cancellationToken)
        => await _uow.Users.Get(request.Id, cancellationToken)
            ?? throw new UserNotFoundException();
}



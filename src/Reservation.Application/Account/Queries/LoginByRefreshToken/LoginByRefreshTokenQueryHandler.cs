namespace Reservation.Application.Account.Queries.LoginByRefreshToken;

public sealed class LoginByRefreshTokenQueryHandler(IUnitOfWork uow, ITokenFactoryService tokenFactory) : IRequestHandler<LoginByRefreshTokenQueryRequest, JwtTokensData>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ITokenFactoryService _tokenFactory = tokenFactory;

    public async Task<JwtTokensData> Handle(LoginByRefreshTokenQueryRequest request, CancellationToken cancellationToken)
    {
        if (request.Role == Role.User)
        {
            var user = await _uow.Users.FindAsync(request.Id, cancellationToken);
            return _tokenFactory.CreateBearerToken(user.Id, Role.User);
        }

        else if (request.Role == Role.Business)
        {

            var business = await _uow.Businesses.FindAsync(request.Id, cancellationToken);
            return _tokenFactory.CreateBearerToken(business.Id, Role.Business);
        }

        else if (request.Role == Role.Admin)
        {
            var admin = await _uow.Users.FindAsync(request.Id, cancellationToken);
            return _tokenFactory.CreateBearerToken(admin.Id, Role.Admin);
        }

        throw new UserOrBusinessNotExistException();
    }
}

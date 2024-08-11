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
            return _tokenFactory.CreateUserToken(user.Id);
        }

        else if (request.Role == Role.Business)
        {

            var business = await _uow.Businesses.FindAsync(request.Id, cancellationToken);
            return _tokenFactory.CreateBusinessToken(business.Id);
        }

        else if (request.Role == Role.Admin)
        {
            var admin = await _uow.Users.FindAsync(request.Id, cancellationToken);
            return _tokenFactory.CreateAdminToken(admin.Id);
        }

        throw new UserOrBusinessNotExistException();
    }
}

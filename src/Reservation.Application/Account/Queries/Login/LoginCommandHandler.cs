namespace Reservation.Application.Account.Queries.Login;


public sealed class LoginCommandHandler(IUnitOfWork uow, ITokenFactoryService tokenFactory) : IRequestHandler<LoginCommandRequest, JwtTokensData>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ITokenFactoryService _tokenFactory = tokenFactory;

    public async Task<JwtTokensData> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.Role == Role.User)
        {
            if (request.CodeActual == request.CodeExpected)
            {
                var user = await _uow.Users.FindByNumber(request.PhoneNumber, cancellationToken);
                var tokens = _tokenFactory.CreateUserToken(user);

                // Modified
                user.Role = Role.User;

                // Save Information
                await _uow.SaveChangeAsync(cancellationToken);

                return tokens;

            }
            else
            {
                throw new NotEqualActualAndExpectedException();
            }

        }
        else if (request.Role == Role.Business)
        {
            if (request.CodeActual == request.CodeExpected)
            {
                var business = await _uow.Businesses.FindAsyncByPhoneNumber(request.PhoneNumber, cancellationToken);
                return _tokenFactory.CreateBusinessToken(business);
            }
            else
            {
                throw new NotEqualActualAndExpectedException();
            }
        }

        throw new UserOrBusinessNotExistException();
    }
}
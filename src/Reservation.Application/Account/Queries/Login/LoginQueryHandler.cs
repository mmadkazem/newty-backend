namespace Reservation.Application.Account.Queries.Login;


public sealed class LoginQueryHandler(IUnitOfWork uow,
                                    ITokenFactoryService tokenFactory,
                                    ICacheProvider cache)
    : IRequestHandler<LoginQueryRequest, JwtTokensData>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ITokenFactoryService _tokenFactory = tokenFactory;
    private readonly ICacheProvider _cache = cache;

    public async Task<JwtTokensData> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
    {
        if (request.Role == Role.User)
        {
            if (request.CodeActual == request.CodeExpected)
            {
                var user = await _uow.Users.FindByNumber(request.PhoneNumber, cancellationToken);
                if (user is null)
                {
                    var userCacheVM = await _cache.GetAsync<UserCacheVM>(nameof(User) + request.PhoneNumber);

                    User finalUser = new()
                    {
                        FullName = userCacheVM.Name,
                        PhoneNumber = userCacheVM.PhoneNumber,
                        Role = Role.User
                    };
                    _uow.Users.Add(finalUser);
                    await _uow.SaveChangeAsync(cancellationToken);

                    return _tokenFactory.CreateUserToken(finalUser);
                }

                return _tokenFactory.CreateUserToken(user); ;

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
                if (business is null)
                {
                    var businessCacheVM = await _cache.GetAsync<BusinessCacheVM>(nameof(Business) + request.PhoneNumber);

                    var city = await _uow.Cities.FindAsyncByName(businessCacheVM.City, cancellationToken);
                    Business finalBusiness = new()
                    {
                        City = city,
                        PhoneNumber = businessCacheVM.PhoneNumber,
                    };
                    _uow.Businesses.Add(finalBusiness);
                    await _uow.SaveChangeAsync(cancellationToken);

                    return _tokenFactory.CreateBusinessToken(finalBusiness);
                }

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
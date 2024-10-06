namespace Reservation.Application.Account.Queries.Login;


public sealed class LoginQueryHandler(IUnitOfWork uow,
                                    ITokenFactoryService tokenFactory,
                                    ICacheProvider cache)
    : IRequestHandler<LoginQueryRequest, LoginQueryResponse>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ITokenFactoryService _tokenFactory = tokenFactory;
    private readonly ICacheProvider _cache = cache;

    public async Task<LoginQueryResponse> Handle(LoginQueryRequest request, CancellationToken cancellationToken)
    {
        if (request.Role == Role.User)
        {
            try
            {
                var userLogin = await _cache.GetAsync<UserLoginCacheVM>(UserLoginCacheVM.ToKey(request.PhoneNumber), cancellationToken);

                if (userLogin.OTPCode != request.Code)
                {
                    throw new NotEqualActualAndExpectedException();
                }

                if (userLogin.IsFirst)
                {
                    User finalUser = new()
                    {
                        FullName = userLogin.Name,
                        PhoneNumber = userLogin.PhoneNumber,
                        Role = Role.User,
                        IsActive = true,
                        Wallet = new()
                    };
                    _uow.Users.Add(finalUser);
                    await _uow.SaveChangeAsync(cancellationToken);

                    await _cache.RemoveAsync(UserLoginCacheVM.ToKey(request.PhoneNumber), cancellationToken);
                    await _cache.RemoveAsync(UserRegisterCacheVM.ToKey(request.PhoneNumber), cancellationToken);

                    return new(_tokenFactory.CreateBearerToken(finalUser.Id, Role.User, finalUser.PhoneNumber, finalUser.FullName), AccountSuccessMessage.Registered);
                }

                await _uow.Users.Active(userLogin.Id, cancellationToken);

                await _cache.RemoveAsync(UserLoginCacheVM.ToKey(request.PhoneNumber), cancellationToken);

                return new(_tokenFactory.CreateBearerToken(userLogin.Id, Role.User, userLogin.PhoneNumber, userLogin.Name), AccountSuccessMessage.loggedIn);
            }
            catch { }
        }
        else if (request.Role == Role.Business)
        {
            try
            {
                var businessLogin = await _cache.GetAsync<BusinessLoginCacheVM>(BusinessLoginCacheVM.ToKey(request.PhoneNumber), cancellationToken);
                if (businessLogin.OTPCode != request.Code)
                {
                    throw new NotEqualActualAndExpectedException();
                }

                if (businessLogin.IsFirst)
                {
                    var city = await _uow.Cities.FindAsyncByName(businessLogin.City, cancellationToken);
                    Business finalBusiness = new()
                    {
                        Name = businessLogin.Name,
                        City = city,
                        PhoneNumber = businessLogin.PhoneNumber,
                        IsActive = true,
                    };
                    _uow.Businesses.Add(finalBusiness);
                    await _uow.SaveChangeAsync(cancellationToken);

                    await _cache.RemoveAsync(BusinessLoginCacheVM.ToKey(request.PhoneNumber), cancellationToken);
                    await _cache.RemoveAsync(BusinessRegisterCacheVM.ToKey(request.PhoneNumber), cancellationToken);

                    return new(_tokenFactory.CreateBearerToken(finalBusiness.Id, Role.Business, finalBusiness.PhoneNumber, finalBusiness.Name), AccountSuccessMessage.Registered);
                }

                await _uow.Businesses.Active(businessLogin.Id, cancellationToken);

                await _cache.RemoveAsync(BusinessLoginCacheVM.ToKey(request.PhoneNumber), cancellationToken);

                return new(_tokenFactory.CreateBearerToken(businessLogin.Id, Role.Business, businessLogin.PhoneNumber, businessLogin.Name), AccountSuccessMessage.loggedIn);
            }
            catch { }
        }

        throw new UserOrBusinessNotExistException();
    }
}

public readonly record struct LoginQueryResponse(JwtTokensData JwtTokens, string Message);
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
                        IsActive = true
                    };
                    _uow.Users.Add(finalUser);
                    await _uow.SaveChangeAsync(cancellationToken);

                    await _cache.RemoveAsync(UserLoginCacheVM.ToKey(request.PhoneNumber), cancellationToken);
                    await _cache.RemoveAsync(UserRegisterCacheVM.ToKey(request.PhoneNumber), cancellationToken);

                    return new(_tokenFactory.CreateBearerToken(finalUser.Id, Role.User), AccountSuccessMessage.Registered);
                }

                var user = await _uow.Users.FindAsyncByNumber(request.PhoneNumber, cancellationToken)
                    ?? throw new UserNotFoundException();

                user.IsActive = true;
                await _uow.SaveChangeAsync(cancellationToken);

                await _cache.RemoveAsync(UserLoginCacheVM.ToKey(request.PhoneNumber), cancellationToken);

                return new(_tokenFactory.CreateBearerToken(user.Id, Role.User), AccountSuccessMessage.loggedIn);
            }
            catch { }
        }
        else if (request.Role == Role.Business)
        {
            try
            {
                var businessCacheVM = await _cache.GetAsync<BusinessLoginCacheVM>(BusinessLoginCacheVM.ToKey(request.PhoneNumber), cancellationToken);
                if (businessCacheVM.OTPCode != request.Code)
                {
                    throw new NotEqualActualAndExpectedException();
                }

                if (businessCacheVM.IsFirst)
                {
                    var city = await _uow.Cities.FindAsyncByName(businessCacheVM.City, cancellationToken);
                    Business finalBusiness = new()
                    {
                        City = city,
                        PhoneNumber = businessCacheVM.PhoneNumber,
                        IsActive = true
                    };
                    _uow.Businesses.Add(finalBusiness);
                    await _uow.SaveChangeAsync(cancellationToken);

                    await _cache.RemoveAsync(BusinessLoginCacheVM.ToKey(request.PhoneNumber), cancellationToken);
                    await _cache.RemoveAsync(BusinessRegisterCacheVM.ToKey(request.PhoneNumber), cancellationToken);

                    return new(_tokenFactory.CreateBearerToken(finalBusiness.Id, Role.Business), AccountSuccessMessage.Registered);
                }

                var business = await _uow.Businesses.FindAsyncByPhoneNumber(request.PhoneNumber, cancellationToken)
                    ?? throw new BusinessNotFoundException();

                business.IsActive = true;
                await _uow.SaveChangeAsync(cancellationToken);

                await _cache.RemoveAsync(BusinessLoginCacheVM.ToKey(request.PhoneNumber), cancellationToken);

                return new(_tokenFactory.CreateBearerToken(business.Id, Role.Business), AccountSuccessMessage.loggedIn);
            }
            catch { }
        }

        throw new UserOrBusinessNotExistException();
    }
}

public readonly record struct LoginQueryResponse(JwtTokensData JwtTokens, string Message);
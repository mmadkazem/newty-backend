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
            var user = await _uow.Users.FindAsyncByNumber(request.PhoneNumber, cancellationToken);
            if (user is null)
            {
                var userCacheVM = await _cache.GetAsync<UserCacheVM>(nameof(User) + request.PhoneNumber);
                if (userCacheVM.OTPCode != request.Code)
                {
                    throw new NotEqualActualAndExpectedException();
                }

                User finalUser = new()
                {
                    FullName = userCacheVM.Name,
                    PhoneNumber = userCacheVM.PhoneNumber,
                    Role = Role.User,
                    IsActive = true
                };
                _uow.Users.Add(finalUser);
                await _uow.SaveChangeAsync(cancellationToken);

                return _tokenFactory.CreateUserToken(finalUser);
            }

            if (user.OTPCode != request.Code)
            {
                throw new NotEqualActualAndExpectedException();
            }

            user.IsActive = true;
            return _tokenFactory.CreateUserToken(user);

        }
        else if (request.Role == Role.Business)
        {
            var business = await _uow.Businesses.FindAsyncByPhoneNumber(request.PhoneNumber, cancellationToken);
            if (business is null)
            {
                var businessCacheVM = await _cache.GetAsync<BusinessCacheVM>(nameof(Business) + request.PhoneNumber);
                if (businessCacheVM.OTPCode != request.Code)
                {
                    throw new NotEqualActualAndExpectedException();
                }

                var city = await _uow.Cities.FindAsyncByName(businessCacheVM.City, cancellationToken);
                Business finalBusiness = new()
                {
                    City = city,
                    PhoneNumber = businessCacheVM.PhoneNumber,
                    IsActive = true
                };
                _uow.Businesses.Add(finalBusiness);
                await _uow.SaveChangeAsync(cancellationToken);

                return _tokenFactory.CreateBusinessToken(finalBusiness);
            }

            if (business.OTPCode != request.Code)
            {
                throw new NotEqualActualAndExpectedException();
            }

            business.IsActive = true;
            return _tokenFactory.CreateBusinessToken(business);

        }

        throw new UserOrBusinessNotExistException();
    }
}
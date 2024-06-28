namespace Reservation.Application.Account.Queries.LoginInit;

public sealed class LoginInitQueryHandler
        (IUnitOfWork uow, ITokenFactoryService tokenFactory,
        ISmsProvider smsProvider, ICacheProvider cache)
    : IRequestHandler<LoginInitQueryRequest, string>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ICacheProvider _cache = cache;
    private readonly ITokenFactoryService _tokenFactory = tokenFactory;
    private readonly ISmsProvider _smsProvider = smsProvider;

    public async Task<string> Handle(LoginInitQueryRequest request, CancellationToken cancellationToken)
    {
        var user = await _uow.Users.FindAsyncByNumber(request.PhoneNumber, cancellationToken);
        var code = StringUtils.GetUniqueKey(5);
        if (user is not null)
        {
            user.OTPCode = code;
            // await _smsProvider.SendLookup(request.PhoneNumber, code);
            return _tokenFactory.CreateTempToken(code, request.PhoneNumber, Role.User).TempToken;
        }

        var business = await _uow.Businesses.FindAsyncByPhoneNumber(request.PhoneNumber, cancellationToken);
        if (business is not null)
        {
            business.OTPCode = code;
            // await _smsProvider.SendLookup(request.PhoneNumber, code);
            return _tokenFactory.CreateTempToken(code, request.PhoneNumber, Role.Business).TempToken;
        }
        try
        {
            var userCache = await _cache.GetAsync<UserCacheVM>(nameof(User) + request.PhoneNumber);
            if (userCache is not null)
            {
                return  _tokenFactory.CreateTempToken(userCache.OTPCode, request.PhoneNumber, Role.User).TempToken;
            }
        }
        catch (Exception) { }
        try
        {
            var businessCache = await _cache.GetAsync<BusinessCacheVM>(nameof(Business) + request.PhoneNumber);
            if (businessCache is not null)
            {
                return _tokenFactory.CreateTempToken(businessCache.OTPCode, request.PhoneNumber, Role.Business).TempToken;
            }
        }
        catch (Exception) { }

        throw new UserOrBusinessNotExistException();
    }
}
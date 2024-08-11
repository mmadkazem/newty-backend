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
        var code = StringUtils.GetUniqueKey(5);
        var user = await _uow.Users.FindAsyncByNumber(request.PhoneNumber, cancellationToken);
        if (user is not null)
        {
            if (user.Role == Role.Admin)
            {
                await _cache.SetAsync<UserLoginCacheVM>("Admin" + request.PhoneNumber, new(user.Id, user.PhoneNumber, code, false), TimeSpan.FromMinutes(2), cancellationToken);
                return _tokenFactory.CreateTempToken(code, request.PhoneNumber, Role.Admin);
            }

            await _cache.SetAsync<UserLoginCacheVM>(UserLoginCacheVM.ToKey(request.PhoneNumber), new(user.Id, user.PhoneNumber, code, false), TimeSpan.FromMinutes(2), cancellationToken);

            // await _smsProvider.SendLookup(request.PhoneNumber, code, user.FullName);
            return _tokenFactory.CreateTempToken(code, request.PhoneNumber, Role.User);
        }

        var business = await _uow.Businesses.FindAsyncByPhoneNumber(request.PhoneNumber, cancellationToken);
        if (business is not null)
        {
            await _cache.SetAsync<BusinessLoginCacheVM>(BusinessLoginCacheVM.ToKey(business.PhoneNumber), new(business.Id, business.PhoneNumber, code, false), TimeSpan.FromMinutes(2), cancellationToken);
            await _uow.SaveChangeAsync(cancellationToken);

            // await _smsProvider.SendLookup(request.PhoneNumber, code);
            return _tokenFactory.CreateTempToken(code, request.PhoneNumber, Role.Business);
        }

        try
        {
            var userCache = await _cache.GetAsync<UserRegisterCacheVM>(UserRegisterCacheVM.ToKey(request.PhoneNumber), cancellationToken);
            if (userCache is not null)
            {
                await _cache.SetAsync<UserLoginCacheVM>(UserLoginCacheVM.ToKey(userCache.PhoneNumber), new(Guid.Empty, userCache.PhoneNumber, code, true, userCache.Name), TimeSpan.FromMinutes(2), cancellationToken);
                return _tokenFactory.CreateTempToken(code, request.PhoneNumber, Role.User);
            }
        }
        catch { }
        try
        {
            var businessCache = await _cache.GetAsync<BusinessRegisterCacheVM>(BusinessRegisterCacheVM.ToKey(request.PhoneNumber), cancellationToken);
            if (businessCache is not null)
            {
                await _cache.SetAsync<BusinessLoginCacheVM>(BusinessLoginCacheVM.ToKey(businessCache.PhoneNumber), new(Guid.Empty, businessCache.PhoneNumber, code, true, businessCache.City), TimeSpan.FromMinutes(2), cancellationToken);
                return _tokenFactory.CreateTempToken(code, request.PhoneNumber, Role.Business);
            }
        }
        catch { }

        throw new UserOrBusinessNotExistException();
    }
}
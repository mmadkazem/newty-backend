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
        var anyUser = await _uow.Users.AnyAsync(request.PhoneNumber, cancellationToken);
        var code = StringUtils.GetUniqueKey(5);
        if (anyUser)
        {
            // await _smsProvider.SendLookup(request.PhoneNumber, code);
            return _tokenFactory.CreateTempToken(code, request.PhoneNumber, Role.User).TempToken;
        }

        var anyBusiness = await _uow.Businesses.AnyAsync(request.PhoneNumber, cancellationToken);
        if (anyBusiness)
        {
            // await _smsProvider.SendLookup(request.PhoneNumber, code);
            return _tokenFactory.CreateTempToken(code, request.PhoneNumber, Role.Business).TempToken;
        }
        try
        {
            var user = await _cache.GetAsync<UserCacheVM>(nameof(User) + request.PhoneNumber);
            if (user is not null)
            {
                return  _tokenFactory.CreateTempToken(code, request.PhoneNumber, Role.User).TempToken;
            }
        }
        catch (Exception) { }
        try
        {
            var business = await _cache.GetAsync<BusinessCacheVM>(nameof(Business) + request.PhoneNumber);
            if (business is not null)
            {
                return _tokenFactory.CreateTempToken(code, request.PhoneNumber, Role.Business).TempToken;
            }
        }
        catch (Exception) { }

        throw new UserOrBusinessNotExistException();
    }
}
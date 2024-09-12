namespace Reservation.Application.Account.Queries.AdminLogin;

public sealed class AdminLoginQueryHandler(ICacheProvider cache, ITokenFactoryService tokenFactory, IUnitOfWork uow) : IRequestHandler<AdminLoginQueryRequest, AdminLoginQueryResponse>
{
    private readonly ICacheProvider _cache = cache;
    private readonly ITokenFactoryService _tokenFactory = tokenFactory;
    private readonly IUnitOfWork _uow = uow;

    public async Task<AdminLoginQueryResponse> Handle(AdminLoginQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var adminCache = await _cache.GetAsync<UserLoginCacheVM>("Admin" + request.PhoneNumber, cancellationToken);

            if (adminCache.OTPCode != request.Code)
            {
                throw new NotEqualActualAndExpectedException();
            }

            var admin = await _uow.Users.FindAsyncByNumber(request.PhoneNumber, cancellationToken)
                ?? throw new UserNotFoundException();

            admin.IsActive = true;
            await _uow.SaveChangeAsync(cancellationToken);


            return new(_tokenFactory.CreateBearerToken(adminCache.Id, Role.Admin, adminCache.PhoneNumber, adminCache.Name), AccountSuccessMessage.loggedIn);
        }
        catch
        {
            throw new OTPCodeExpiredException();
        }
    }
}
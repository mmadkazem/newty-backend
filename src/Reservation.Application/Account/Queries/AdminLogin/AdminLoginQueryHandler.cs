namespace Reservation.Application.Account.Queries.AdminLogin;

public sealed class AdminLoginQueryHandler(ICacheProvider cache, ITokenFactoryService tokenFactory) : IRequestHandler<AdminLoginQueryRequest, AdminLoginQueryResponse>
{
    private readonly ICacheProvider _cache = cache;
    private readonly ITokenFactoryService _tokenFactory = tokenFactory;

    public async Task<AdminLoginQueryResponse> Handle(AdminLoginQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var admin = await _cache.GetAsync<UserLoginCacheVM>("Admin" + request.PhoneNumber, cancellationToken);
    
            if (admin.OTPCode != request.Code)
            {
                throw new NotEqualActualAndExpectedException();
            }
    
            return new(_tokenFactory.CreateBearerToken(admin.Id, Role.Admin), AccountSuccessMessage.loggedIn);
        }
        catch 
        {
            throw new OTPCodeExpiredException();
        }
    }
}
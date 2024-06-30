namespace Reservation.Application.Account.Queries.AdminLogin;


public record AdminLoginQueryRequest(string PhoneNumber, string Code) : IRequest<JwtTokensData>;

public sealed class AdminLoginQueryHandler(IUnitOfWork uow, ITokenFactoryService tokenFactory) : IRequestHandler<AdminLoginQueryRequest, JwtTokensData>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ITokenFactoryService _tokenFactory = tokenFactory;

    public async Task<JwtTokensData> Handle(AdminLoginQueryRequest request, CancellationToken cancellationToken)
    {
        var admin = await _uow.Users.FindAsyncByNumber(request.PhoneNumber, cancellationToken);

        if (admin.OTPCode != request.Code)
        {
            throw new NotEqualActualAndExpectedException();
        }

        return _tokenFactory.CreateAdminToken(admin);
    }
}
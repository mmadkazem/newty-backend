namespace Reservation.Application.Account.Queries.AdminLogin;

public sealed class AdminLoginQueryHandler(IUnitOfWork uow, ITokenFactoryService tokenFactory) : IRequestHandler<AdminLoginQueryRequest, AdminLoginQueryResponse>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ITokenFactoryService _tokenFactory = tokenFactory;

    public async Task<AdminLoginQueryResponse> Handle(AdminLoginQueryRequest request, CancellationToken cancellationToken)
    {
        var admin = await _uow.Users.FindAsyncByNumber(request.PhoneNumber, cancellationToken);

        if (admin.OTPCode != request.Code)
        {
            throw new NotEqualActualAndExpectedException();
        }

        return new(_tokenFactory.CreateAdminToken(admin), AccountSuccessMessage.loggedIn);
    }
}
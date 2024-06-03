namespace Reservation.Application.Account.Queries.LoginInit;

public sealed class LoginInitQueryHandler(IUnitOfWork uow, ITokenFactoryService tokenFactory, ISmsProvider smsProvider)
    : IRequestHandler<LoginInitQueryRequest, string>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly ITokenFactoryService _tokenFactory = tokenFactory;
    private readonly ISmsProvider _smsProvider = smsProvider;

    public async Task<string> Handle(LoginInitQueryRequest request, CancellationToken cancellationToken)
    {
        var anyUser = await _uow.Users.AnyAsync(request.PhoneNumber, cancellationToken);
        if (anyUser)
        {
            var code = StringUtils.GetUniqueKey(5);
            // await _smsProvider.SendLookup(request.PhoneNumber, code);
            return _tokenFactory.CreateTempToken(code, request.PhoneNumber, Role.User).TempToken;
        }

        var anyBusiness = await _uow.Businesses.AnyAsync(request.PhoneNumber, cancellationToken);
        if (anyBusiness)
        {
            var code = StringUtils.GetUniqueKey(5);
            // await _smsProvider.SendLookup(request.PhoneNumber, code);
            return _tokenFactory.CreateTempToken(code, request.PhoneNumber, Role.Business).TempToken;
        }
        if (false)
        {

        }
        throw new UserOrBusinessNotExistException();
    }
}
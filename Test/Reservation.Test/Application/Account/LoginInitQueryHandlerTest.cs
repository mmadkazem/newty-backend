using Reservation.Application.Account.Queries.LoginInit;
using Reservation.Application.ExternalServices.Jwt;
using Reservation.Application.ExternalServices.SmsProvider;

namespace Reservation.Test.Application.Account;

public sealed class LoginInitQueryHandlerTest
{
    async Task Act(LoginInitQueryRequest request)
        => await _requestHandler.Handle(request, CancellationToken.None);



    #region ARRANGE

    private readonly ITokenFactoryService _tokenFactory;
    private readonly ISmsProvider _smsProvider;
    private readonly ICacheProvider _cache;
    private readonly IUnitOfWork _uow;

    private readonly IRequestHandler<LoginInitQueryRequest, string> _requestHandler;
    public LoginInitQueryHandlerTest()
    {
        _cache = Substitute.For<ICacheProvider>();
        _tokenFactory = Substitute.For<ITokenFactoryService>();
        _smsProvider = Substitute.For<ISmsProvider>();
        _uow = Substitute.For<IUnitOfWork>();

        _requestHandler = new LoginInitQueryHandler(_uow, _tokenFactory, _smsProvider, _cache);
    }

    #endregion
}
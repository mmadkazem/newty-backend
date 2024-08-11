namespace Reservation.Test.Application.Account;

public class RegisterUserCommandHandlerTest
{
    async Task Act(RegisterUserCommandRequest request)
        => await _requestHandler.Handle(request, CancellationToken.None);

    [Fact]
    public async void HandleAsync_Calls_UnitOfWork_UserRepository_Add_On_Success()
    {
        // ARRANGE
        var request = new RegisterUserCommandRequest("Test", "09386743145");

        // ACT
        await Act(request);

        // ASSERT
        // await _cache.Received(1).SetAsync(Arg.Any<string>(),Arg.Any<UserRegisterCacheVM>());
    }


    #region ARRANGE

    private readonly ICacheProvider _cache;

    private readonly IRequestHandler<RegisterUserCommandRequest> _requestHandler;
    public RegisterUserCommandHandlerTest()
    {
        _cache = Substitute.For<ICacheProvider>();

        _requestHandler = new RegisterUserCommandHandler(_cache);
    }

    #endregion
}
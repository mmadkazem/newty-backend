namespace Reservation.Test.Application.Account;

// public class RegisterUserCommandHandlerTest
// {
//     async Task Act(RegisterUserCommandRequest request)
//         => await _requestHandler.Handle(request, CancellationToken.None);

//     [Fact]
//     public async void HandleAsync_Calls_UnitOfWork_UserRepository_Add_On_Success()
//     {
//         // ARRANGE
//         var request = new RegisterUserCommandRequest("Test", "09386743145");

//         // ACT
//         await Act(request);

//         // ASSERT
//         _uow.Users.Received(1).Add(Arg.Any<User>());
//     }

//     [Fact]
//     public async void HandleAsync_Calls_UnitOfWork_SaveChange_On_Success()
//     {
//         // ARRANGE
//         var request = new RegisterUserCommandRequest("Test", "09386743145");

//         // ACT
//         await Act(request);

//         // ASSERT
//         await _uow.Received(1).SaveChangeAsync();
//     }


//     #region ARRANGE

//     private readonly IUnitOfWork _uow;

//     private readonly IRequestHandler<RegisterUserCommandRequest> _requestHandler;
//     public RegisterUserCommandHandlerTest()
//     {
//         _uow = Substitute.For<IUnitOfWork>();

//         _requestHandler = new RegisterUserCommandHandler(_uow);
//     }

//     #endregion
// }
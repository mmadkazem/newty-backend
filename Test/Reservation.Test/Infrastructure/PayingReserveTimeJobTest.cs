// using Moq;

// namespace Reservation.Test.Infrastructure;

// public sealed class PayingReserveTimeJobTest
// {
//     [Fact]
//     public void Paying_ReserveTime_User_BusinessReceipt_Successful()
//     {
//         // ARRANGE
//         var option = new DbContextOptionsBuilder<NewtyDbContext>()
//                 .UseInMemoryDatabase("ShouldAddCartTest", b => b.EnableNullChecks(false))
//                 .Options;
//         using NewtyDbContext _context = new(option);
//         AddMockItem(_context);

//         // ACT
//         PayingReserveTimeJobImpletion.PayingReserveTime(_context);

//         // ASSERT
//         var wallet1 = _context.Businesses.Where(b => b.Name == "Business Test1").Select(b => b.Wallet).First();
//         var wallet2 = _context.Businesses.Where(b => b.Name == "Business Test2").Select(b => b.Wallet).First();

//         Assert.Equal(99_000, wallet1.Credit);
//         Assert.Equal(198_000, wallet1.Credit);
//     }



//     #region ARRANGE
//     private static void AddMockItem(NewtyDbContext _context)
//     {
//         Business business1 = new() { Id = Guid.NewGuid(), Name = "Business Test1", Wallet = new() { Credit = 0 } };
//         Business business2 = new() { Id = Guid.NewGuid(), Name = "Business Test2", Wallet = new() { Credit = 0 } };
//         _context.Businesses.AddRange([business1, business2]);

//         User user1 = new() { Id = Guid.NewGuid(), FullName = "User Test1", Wallet = new() { BlockCredit = 100_000 } };
//         User user2 = new() { Id = Guid.NewGuid(), FullName = "User Test2", Wallet = new() { BlockCredit = 200_000 } };
//         User admin = new() { Id = Guid.NewGuid(), PhoneNumber = "09111111111", FullName = "admin Test", Wallet = new() { Credit = 0 } };
//         _context.Users.AddRange([user1, user2, admin]);

//         ReserveTimeReceipt reserveTime1 = new() { Id = Guid.NewGuid(), BusinessReceiptId = business1.Id, UserId = user1.Id, TotalStartDate = DateTime.Now.AddDays(-1), State = ReserveState.Confirmed, TotalPrice = 100_000 };
//         ReserveTimeReceipt reserveTime2 = new() { Id = Guid.NewGuid(), BusinessReceiptId = business2.Id, UserId = user2.Id, TotalStartDate = DateTime.Now.AddDays(-1), State = ReserveState.Confirmed, TotalPrice = 200_000 };
//         _context.ReserveTimesReceipt.AddRange([reserveTime1, reserveTime2]);

//         TransferFee transferFee = new() { Percent = 1 };
//         _context.TransferFees.Add(transferFee);
//         _context.SaveChanges();
//     }
//     // private readonly IServiceScopeFactory _serviceFactory;
//     // private readonly IPayingReserveTimeJob _job;
//     // private readonly IServiceScope _serviceScope;
//     // private readonly IServiceProvider _serviceProvider;
//     // public PayingReserveTimeJobTest()
//     // {
//     //     _serviceFactory = Substitute.For<IServiceScopeFactory>();
//     //     _serviceProvider = Substitute.For<IServiceProvider>();
//     //     _serviceScope = Substitute.For<IServiceScope>();

//     // }
//     #endregion
// }



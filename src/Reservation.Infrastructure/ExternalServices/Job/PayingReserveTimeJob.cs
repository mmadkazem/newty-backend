namespace Reservation.Infrastructure.ExternalServices.Job;



public sealed class PayingReserveTimeJob(IServiceScopeFactory scopeFactory) : IPayingReserveTimeJob
{
    private readonly IServiceScopeFactory _scopeFactory = scopeFactory;

    public void Execute()
    {
        using var serviceScope = _scopeFactory.CreateScope();
        var recurring = serviceScope.ServiceProvider.GetService<IRecurringJobManager>();
        recurring.AddOrUpdate("PayingReserveTime", () => PayingReserveTime(), Cron.Daily(1, 0));
    }

    public void PayingReserveTime()
    {
        // using var serviceScope = _scopeFactory.CreateScope();
        // using var _context = serviceScope.ServiceProvider.GetService<ReservationDbContext>();
        // var count = 0;

        // #region Get Admin Information
        // Env.Load();
        // var adminPhonNumber = Env.GetString("ADMIN_PHONE_NUMBER");
        // var adminWallet = _context.Users.AsQueryable()
        //                                 .Where(u => u.PhoneNumber == adminPhonNumber)
        //                                 .Select(u => u.Wallet)
        //                                 .FirstOrDefault();

        // var transferFee = _context.TransferFees.FirstOrDefault();
        // #endregion
        // // var WalletAdmin
        // while (true)
        // {
        //     var businessId = _context.Businesses.AsQueryable()
        //             .Skip(count).Select(b => b.Id)
        //             .FirstOrDefault();
        //     if (businessId == Guid.Empty)
        //     {
        //         return;
        //     }
        //     count++;

        //     for (int j = 0; true; j++)
        //     {
        //         var reserveTimes = _context.ReserveTimesReceipt.AsQueryable()
        //                                     .Where
        //                                     (
        //                                         r => r.BusinessReceiptId == businessId &&
        //                                         r.TotalStartDate.Day == DateTime.Now.AddDays(1).Day &&
        //                                         r.State == ReserveState.Confirmed
        //                                     )
        //                                     .Include(r => r.BusinessReceipt)
        //                                     .Include(r => r.BusinessSender)
        //                                     .Include(r => r.User)
        //                                     .AsSplitQuery()
        //                                     .Skip(j * 25)
        //                                     .Take(25)
        //                                     .ToList();

        //         if (reserveTimes.Count == 0)
        //         {
        //             return;
        //         }

        //         foreach (var reserveTime in reserveTimes)
        //         {
        //             if (reserveTime.BusinessReceipt is null)
        //             {
        //                 continue;
        //             }

        //             var businessReceiptWallet = _context.Businesses.AsQueryable()
        //                             .Select(u => u.Wallet)
        //                             .FirstOrDefault(u => u.Id == reserveTime.BusinessReceiptId);
        //             if (businessReceiptWallet is null)
        //             {
        //                 continue;
        //             }
        //             // Paying the hours of a business
        //             if (reserveTime.BusinessSender is not null)
        //             {
        //                 var businessSenderWallet = _context.Users.AsQueryable()
        //                             .Select(u => u.Wallet)
        //                             .FirstOrDefault(u => u.Id == reserveTime.BusinessSenderId);
        //                 if (businessSenderWallet is null)
        //                 {
        //                     continue;
        //                 }

        //                 // Deduct from the user wallet
        //                 if (businessReceiptWallet.BlockCredit - reserveTime.TransactionReceipt.Amount < 0)
        //                 {
        //                     continue;
        //                 }
        //                 businessSenderWallet.BlockCredit -= reserveTime.TransactionReceipt.Amount;

        //                 // Transfer to business wallet
        //                 businessReceiptWallet.Credit += reserveTime.TransactionReceipt.Amount;

        //                 // Transfer to admin wallet Transfer Fee
        //                 businessReceiptWallet.Credit -= transferFee.Percent * reserveTime.TransactionReceipt.Amount / 100;
        //                 adminWallet.Credit += transferFee.Percent * reserveTime.TransactionReceipt.Amount / 100;
        //                 reserveTime.IsPay = true;
        //                 _context.SaveChanges();

        //                 continue;
        //             }
        //             // Paying the hours of a user
        //             if (reserveTime.User is not null)
        //             {
        //                 var userWallet = _context.Users.AsQueryable()
        //                     .Select(u => u.Wallet)
        //                     .FirstOrDefault(u => u.Id == reserveTime.UserId);
        //                 if (userWallet is null)
        //                 {
        //                     continue;
        //                 }
        //                 // Deduct from the user wallet
        //                 if (userWallet.BlockCredit - reserveTime.TransactionReceipt.Amount < 0)
        //                 {
        //                     continue;
        //                 }
        //                 userWallet.BlockCredit -= reserveTime.TransactionReceipt.Amount;

        //                 // Transfer to business wallet
        //                 businessReceiptWallet.Credit += reserveTime.TransactionReceipt.Amount;

        //                 businessReceiptWallet.Credit -= transferFee.Percent * reserveTime.TransactionReceipt.Amount / 100;
        //                 adminWallet.Credit += transferFee.Percent * reserveTime.TransactionReceipt.Amount / 100;
        //                 reserveTime.IsPay = true;
        //                 _context.SaveChanges();
        //             }
        //         }
        //     }
        // }
    }
}
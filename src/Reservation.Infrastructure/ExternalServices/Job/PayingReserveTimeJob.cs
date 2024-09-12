namespace Reservation.Infrastructure.ExternalServices.Job;



public sealed class PayingReserveTimeJob(IRecurringJobManager recurring) : IPayingReserveTimeJob
{
    private readonly IRecurringJobManager _recurring = recurring;

    public void Execute()
    {
        _recurring.AddOrUpdate<PayingReserveTimeExecution>("PayingReserveTime", e => e.PayingReserveTime(), Cron.Daily());
    }
}

public sealed class PayingReserveTimeExecution(NewtyDbContext context)
{
    private readonly NewtyDbContext _context = context;

    public void PayingReserveTime()
    {
        var count = 0;
        #region Get Admin Information
        Env.Load();
        var adminPhonNumber = Env.GetString("ADMIN_PHONE_NUMBER");
        var adminWallet = _context.Users.AsQueryable()
                                        .Where(u => u.PhoneNumber == adminPhonNumber)
                                        .Select(u => u.Wallet)
                                        .FirstOrDefault();

        var transferFee = _context.TransferFees.FirstOrDefault();
        #endregion
        while (true)
        {
            var businessId = _context.Businesses.AsQueryable()
                    .Skip(count).Select(b => b.Id)
                    .FirstOrDefault();
            if (businessId == Guid.Empty)
            {
                return;
            }
            count++;

            for (int j = 0; true; j++)
            {
                var reserveTimes = _context.ReserveTimesReceipt.AsQueryable()
                                            .Where
                                            (
                                                r => r.BusinessReceiptId == businessId &&
                                                r.TotalStartDate.Day == DateTime.Now.AddDays(1).Day &&
                                                r.State == ReserveState.Confirmed
                                            )
                                            .Include(r => r.BusinessReceipt)
                                            .Include(r => r.BusinessSender)
                                            .Include(r => r.User)
                                            .AsSplitQuery()
                                            .Skip(j * 25)
                                            .Take(25)
                                            .ToList();

                if (reserveTimes.Count == 0)
                {
                    break;
                }

                foreach (var reserveTime in reserveTimes)
                {
                    if (reserveTime.BusinessReceipt is null)
                    {
                        continue;
                    }

                    var businessReceiptWallet = _context.Businesses.AsQueryable()
                                    .Select(u => u.Wallet)
                                    .FirstOrDefault(u => u.Id == reserveTime.BusinessReceiptId);
                    if (businessReceiptWallet is null)
                    {
                        continue;
                    }
                    // Paying the hours of a business
                    if (reserveTime.BusinessSender is not null)
                    {
                        var businessSenderWallet = _context.Users.AsQueryable()
                                    .Select(u => u.Wallet)
                                    .FirstOrDefault(u => u.Id == reserveTime.BusinessSenderId);
                        if (businessSenderWallet is null)
                        {
                            continue;
                        }

                        // Deduct from the user wallet
                        if (businessReceiptWallet.BlockCredit - reserveTime.TransactionReceipt.Amount < 0)
                        {
                            continue;
                        }
                        businessSenderWallet.BlockCredit -= reserveTime.TransactionReceipt.Amount;

                        // Transfer to business wallet
                        businessReceiptWallet.Credit += reserveTime.TransactionReceipt.Amount;

                        // Transfer to admin wallet Transfer Fee
                        businessReceiptWallet.Credit -= transferFee.Percent * reserveTime.TransactionReceipt.Amount / 100;
                        adminWallet.Credit += transferFee.Percent * reserveTime.TransactionReceipt.Amount / 100;
                        reserveTime.IsPay = true;
                        _context.SaveChanges();

                        continue;
                    }
                    // Paying the hours of a user
                    if (reserveTime.User is not null)
                    {
                        var userWallet = _context.Users.AsQueryable()
                            .Select(u => u.Wallet)
                            .FirstOrDefault(u => u.Id == reserveTime.UserId);
                        if (userWallet is null)
                        {
                            continue;
                        }
                        // Deduct from the user wallet
                        if (userWallet.BlockCredit - reserveTime.TransactionReceipt.Amount < 0)
                        {
                            continue;
                        }
                        userWallet.BlockCredit -= reserveTime.TransactionReceipt.Amount;

                        // Transfer to business wallet
                        businessReceiptWallet.Credit += reserveTime.TransactionReceipt.Amount;

                        businessReceiptWallet.Credit -= transferFee.Percent * reserveTime.TransactionReceipt.Amount / 100;
                        adminWallet.Credit += transferFee.Percent * reserveTime.TransactionReceipt.Amount / 100;
                        reserveTime.IsPay = true;
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}
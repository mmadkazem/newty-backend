namespace Reservation.Infrastructure.Persistance.Configuration;


public static class SoftDeleteConfiguration
{
    public static void ConfigSoftDeleteFilter(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<Business>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<Artist>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<Post>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<BusinessService>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<SmsCredit>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<SmsTemplate>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<UserVIP>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<Category>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<BusinessRequestPay>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<UserRequestPay>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<Point>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<ReserveTimeReceipt>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<ReserveTimeSender>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<ReserveItem>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<Wallet>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<Transaction>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<City>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<TransferFee>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<SmsPlan>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<Coupon>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<BusinessRequestWithdraw>().HasQueryFilter(f => !f.IsDeleted);
    }
}
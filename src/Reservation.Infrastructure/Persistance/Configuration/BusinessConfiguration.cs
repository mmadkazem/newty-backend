namespace Reservation.Infrastructure.Persistance.Configuration;


public class BusinessConfiguration : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        builder
            .HasOne(b => b.SmsCredit)
            .WithOne(s => s.Business)
            .HasForeignKey<SmsCredit>(s => s.BusinessId);

        builder
            .HasMany(b => b.ReserveTimesSender)
            .WithOne(s => s.BusinessSender)
            .HasForeignKey(s => s.BusinessSenderId);

        builder
            .HasMany(b => b.ReserveTimesReceipt)
            .WithOne(s => s.BusinessReceipt)
            .HasForeignKey(r => r.BusinessReceiptId);
        builder
            .HasMany(b => b.Categories)
            .WithMany(c => c.Businesses);
    }
}
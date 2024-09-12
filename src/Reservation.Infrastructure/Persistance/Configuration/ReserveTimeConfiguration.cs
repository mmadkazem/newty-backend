namespace Reservation.Infrastructure.Persistance.Configuration;


public sealed class ReserveTimeReceiptConfiguration : IEntityTypeConfiguration<ReserveTimeReceipt>
{
    public void Configure(EntityTypeBuilder<ReserveTimeReceipt> builder)
    {
        builder
            .HasOne(r => r.TransactionSender)
            .WithOne();

        builder.HasOne(t => t.BusinessReceipt)
            .WithMany(b => b.ReserveTimesReceipt)
            .HasForeignKey(b => b.BusinessReceiptId)
            .IsRequired();

        builder.Property(t => t.BusinessSenderId)
            .IsRequired(false);

        builder.Property(t => t.UserId)
            .IsRequired(false);
    }
}
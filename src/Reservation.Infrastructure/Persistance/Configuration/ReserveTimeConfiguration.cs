
namespace Reservation.Infrastructure.Persistance.Configuration;


public sealed class ReserveTimeConfiguration : IEntityTypeConfiguration<ReserveTimeReceipt>
{
    public void Configure(EntityTypeBuilder<ReserveTimeReceipt> builder)
    {
        builder
            .HasOne(r => r.TransactionSender)
            .WithOne();
    }
}
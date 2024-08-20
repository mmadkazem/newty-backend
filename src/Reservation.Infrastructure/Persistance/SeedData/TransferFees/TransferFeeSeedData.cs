namespace Reservation.Infrastructure.Persistance.SeedData.TransferFees;


public class TransferFeeSeedData : IEntityTypeConfiguration<TransferFee>
{
    public void Configure(EntityTypeBuilder<TransferFee> builder)
    {
        builder.HasData([new() { Id = Guid.Parse("e2635bc0-c7f5-47cf-88c6-dc9cf3c125a0"), Percent = 1 }]);
    }
}
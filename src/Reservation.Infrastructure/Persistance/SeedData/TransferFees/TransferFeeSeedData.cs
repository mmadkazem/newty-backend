namespace Reservation.Infrastructure.Persistance.SeedData.TransferFees;


public class TransferFeeSeedData : IEntityTypeConfiguration<TransferFee>
{
    public void Configure(EntityTypeBuilder<TransferFee> builder)
    {
        builder.HasData([new() { Id = Guid.NewGuid(), Percent = 1 }]);
    }
}
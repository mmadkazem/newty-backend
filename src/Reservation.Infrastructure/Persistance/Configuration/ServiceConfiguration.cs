namespace Reservation.Infrastructure.Persistance.Configuration;


public sealed class ServiceConfiguration : IEntityTypeConfiguration<BusinessService>
{
    public void Configure(EntityTypeBuilder<BusinessService> builder)
    {
        builder.HasMany(s => s.Coupons)
                .WithOne(c => c.Service)
                .HasForeignKey(c => c.ServiceId);
    }
}
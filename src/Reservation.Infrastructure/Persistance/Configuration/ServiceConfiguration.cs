namespace Reservation.Infrastructure.Persistance.Configuration;


public sealed class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasMany(s => s.Coupons)
                .WithOne(c => c.Service)
                .HasForeignKey(c => c.ServiceId);
    }
}
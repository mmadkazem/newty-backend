using Reservation.Domain.Entities.Businesses;

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
            .HasMany(b => b.ReserveTimesIn)
            .WithOne(s => s.BusinessIn)
            .HasForeignKey(s => s.BusinessInId);

        builder
            .HasMany(b => b.ReserveTimesOut)
            .WithOne(s => s.Business)
            .HasForeignKey(r => r.BusinessId);
    }
}
namespace Reservation.Infrastructure.Persistance.Configuration;


public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(u => u.PhoneNumber);
                builder
            .HasOne(u => u.Wallet);
    }
}
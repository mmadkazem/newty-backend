using Reservation.Domain.Entities.Wallets;

namespace Reservation.Infrastructure.Persistance.Configuration;


public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(u => u.PhoneNumber);
                builder
            .HasOne(u => u.Wallet)
            .WithOne(w => w.User)
            .HasForeignKey<Wallet>(w => w.UserId);
    }
}
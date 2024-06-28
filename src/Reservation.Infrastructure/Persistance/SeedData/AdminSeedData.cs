namespace Reservation.Infrastructure.Persistance.SeedData;


public class AdminSeedData : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        Env.Load();
        User user = new()
        {
            Id = Guid.NewGuid(),
            FullName = Env.GetString("ADMIN_NAME"),
            Role = Role.Admin,
            PhoneNumber = Env.GetString("ADMIN_PHONE_NUMBER")
        };
        builder.HasData(user);
    }
}
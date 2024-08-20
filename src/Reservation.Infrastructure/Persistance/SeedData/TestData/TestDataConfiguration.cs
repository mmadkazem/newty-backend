namespace Reservation.Infrastructure.Persistance.SeedData.TestData;


public static class TestDataConfiguration
{
    public static ModelBuilder SeedTestData(this ModelBuilder builder)
    {

        // builder.Entity<BusinessService>().HasData(service);
        // builder.Entity<Artist>().HasData(artist);
        return builder;
    }
}
namespace Reservation.Infrastructure.Persistance.SeedData.Cities;


public sealed class SeedCityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        string path = Path.Combine
        (
            BaseDirectoryPath.InfrastructureDirectoryPath,
            $@"{BaseDirectoryPath.CityPath}cities.json"
        );
        List<City> cities = [];
        using var r = new StreamReader(path);
        string json = r.ReadToEnd();
        cities = JsonSerializer.Deserialize<List<City>>(json);

        builder.HasData(cities);
    }
}
namespace Reservation.Application.ExternalServices;

public interface IDbInitializerService
{
    /// <summary>
    /// Applies any pending migrations for the context to the database.
    /// Will create the database if it does not already exist.
    /// </summary>
    void Initialize();

    /// <summary>
    /// Adds some default values to the Db
    /// </summary>
    void SeedData();
}
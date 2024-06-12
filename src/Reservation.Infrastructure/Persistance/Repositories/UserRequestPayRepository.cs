namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class UserRequestPayRepository(ReservationDbContext context) : IUserRequestPayRepository
{
    private readonly ReservationDbContext _context = context;
}
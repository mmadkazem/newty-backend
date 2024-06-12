namespace Reservation.Infrastructure.Persistance.Repositories;

public sealed class BusinessRequestPayRepository(ReservationDbContext context) : IBusinessRequestPayRepository
{
    private readonly ReservationDbContext _context = context;

    public void Add(BusinessRequestPay businessRequestPay)
        => _context.BusinessRequestPays.Add(businessRequestPay);

    public async Task<BusinessRequestPay> FindAsync(Guid id, CancellationToken cancellationToken)
        => await _context.BusinessRequestPays.AsQueryable()
                                                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
}

namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class CouponRepository(NewtyDbContext context) : ICouponRepository
{
    private readonly NewtyDbContext _context = context;

    public void Add(Coupon coupon)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AnyAsync(string code, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Coupon> FindAsync(Guid couponId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Remove(Coupon coupon)
    {
        throw new NotImplementedException();
    }

    // public void Add(Coupon coupon)
    //     => _context.Coupons.Add(coupon);

    // public void Remove(Coupon coupon)
    //     => _context.Coupons.Remove(coupon);

    // public async Task<bool> AnyAsync(string code, CancellationToken cancellationToken = default)
    //     => await _context.Coupons.AsQueryable()
    //                             .AnyAsync(c => c.Code == code, cancellationToken);

    // public async Task<Coupon> FindAsync(Guid couponId, CancellationToken cancellationToken)
    //     => await _context.Coupons.AsQueryable()
    //                             .FirstOrDefaultAsync(c => c.Id == couponId, cancellationToken);
}
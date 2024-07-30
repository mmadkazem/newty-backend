namespace Reservation.Domain.Repositories;


public interface ICouponRepository
{
    void Add(Coupon coupon);
    void Remove(Coupon coupon);
    Task<Coupon> FindAsync(Guid couponId, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(string code, CancellationToken cancellationToken = default);
}
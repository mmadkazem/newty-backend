namespace Reservation.Application.ServiceCoupon.Commands.CreateCoupon;


public sealed record CreateCouponCommandRequest
(
    string Code, DateTime Expire,
    Guid ServiceId, Guid BusinessId
) : IRequest
{
    public static CreateCouponCommandRequest Create(Guid businessId, CreateCouponDTO model)
        => new(model.Code, model.Expire, model.ServiceId, businessId);
}

public sealed record CreateCouponDTO(string Code, DateTime Expire, Guid ServiceId);

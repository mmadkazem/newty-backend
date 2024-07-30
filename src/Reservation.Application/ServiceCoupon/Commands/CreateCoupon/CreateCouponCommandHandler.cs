namespace Reservation.Application.ServiceCoupon.Commands.CreateCoupon;

public sealed class CreateCouponCommandHandler(IUnitOfWork uow) : IRequestHandler<CreateCouponCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(CreateCouponCommandRequest request, CancellationToken cancellationToken)
    {
        var service = await _uow.Services.FindAsync(request.ServiceId, cancellationToken)
            ?? throw new ServiceNotFoundException();

        if (service.BusinessId != request.BusinessId)
        {
            throw new DoNotAccessToRemoveItemException("سرویس");
        }

        Coupon coupon = new()
        {
            Code = request.Code,
            Expire = request.Expire,
            Service = service
        };

        _uow.Coupons.Add(coupon);
        await _uow.SaveChangeAsync(cancellationToken);
    }

}
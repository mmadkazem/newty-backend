namespace Reservation.Application.ServiceCoupon.Commands.CreateCoupon;

public sealed class CreateCouponCommandValidator : AbstractValidator<CreateCouponCommandRequest>
{
    private readonly IUnitOfWork _uow;
    public CreateCouponCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;
        RuleFor(b => b.Code)
            .NotEmpty().WithMessage("کد تخفیف نباید خالی باشد لطفا آدرس")
            .MustAsync(AlreadyExistCode).WithMessage("این کد تخفیف وجود دارد")
            .MaximumLength(20).WithMessage("کد تخفیف باید کمتر از 20 حرف باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست لطفا درست وارد کنید");
    }

    private async Task<bool> AlreadyExistCode(string code, CancellationToken token)
        => await _uow.Coupons.AnyAsync(code, token);
}
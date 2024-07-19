namespace Reservation.Application.SmsPlans.Commands.UpdateSmsPlan;

public sealed class UpdateSmsPlanCommandValidator : AbstractValidator<UpdateSmsPlanCommandRequest>
{
    public UpdateSmsPlanCommandValidator()
    {
        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("عنوان نباید خالی باشد لطفا آدرس")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست لطفا درست وارد کنید");

        RuleFor(r => r.Description)
            .NotEmpty().WithMessage("توضیحات نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمات معتبر نیست");

        RuleFor(r => r.CoverImagePath)
            .NotEmpty().WithMessage("آدرس نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست");

        RuleFor(r => r.Price)
            .Must(IsValidPrice).WithMessage("مبلغ وارد شده معتبر نیست");

        RuleFor(r => r.Discount)
            .Must(IsValidDiscount).WithMessage("درصد تخفیف باید بین 0 تا 100 باشد");

        RuleFor(r => r.Count)
            .Must(IsValidNumber).WithMessage("تعداد پیامک باید بیشتر از صفر باشد");

    }

    private bool IsValidPrice(decimal price)
        => price > 0;

    private bool IsValidNumber(int count)
        => count > 0;

    private bool IsValidDiscount(int discount)
        => discount >= 0 && discount <= 100;
}
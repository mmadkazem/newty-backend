namespace Reservation.Application.BusinessServices.Commands.UpdateService;

public sealed class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommandRequest>
{
    public UpdateServiceCommandValidator()
    {
        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("نام خدمات شما نمی تواند خالی باشد")
            .MaximumLength(100).WithMessage("نام خدمات شما نمی تواند بیشتر از 100 کاراکتر باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست");

        RuleFor(s => s.Price)
            .Must(IsValidPrice).WithMessage("مبلغ وارد شده معتبر نیست");

        RuleFor(s => s.Time)
            .Must(IsValidTime).WithMessage("زمان وارد شده معتبر نیست");
    }

    private bool IsValidPrice(int price)
        => price > 10_000;
    private bool IsValidTime(Time time)
        => time.Minute > 5
        && time.Hour < 10;
}
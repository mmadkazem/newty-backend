namespace Reservation.Application.SmsPlans.Commands.CreateSmsPlan;

public sealed class CreateSmsPlanCommandValidator : AbstractValidator<CreateSmsPlanCommandRequest>
{
    private readonly IUnitOfWork _uow;
    public CreateSmsPlanCommandValidator(IUnitOfWork uow)
    {
        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("عنوان نباید خالی باشد لطفا آدرس")
            .MustAsync(AlreadyExistTitle).WithMessage("این عنوان وجود دارد")
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

        _uow = uow;
    }

    private async Task<bool> AlreadyExistTitle(string name, CancellationToken token)
        => !await _uow.SmsPlans.AnyAsync(name, token);

    private bool IsValidPrice(decimal price)
        => price > 0;

    private bool IsValidNumber(int count)
        => count > 0;

    private bool IsValidDiscount(int discount)
        => discount >= 0 && discount <= 100;
}
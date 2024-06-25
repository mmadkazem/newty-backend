namespace Reservation.Application.SmsTemplates.Commands.CreateSmsTemplate;

public sealed class CreateSmsTemplateCommandValidator : AbstractValidator<CreateSmsTemplateCommandRequest>
{
    private readonly IUnitOfWork _uow;
    public CreateSmsTemplateCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("نام نباید خالی باشد لطفا آدرس")
            .MustAsync(AlreadyExistName).WithMessage("این نام وجود دارد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست لطفا درست وارد کنید");

        RuleFor(r => r.Description)
            .NotEmpty().WithMessage("توضیحات نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمات معتبر نیست");
    }

    private async Task<bool> AlreadyExistName(string name, CancellationToken cancellationToken)
        => !await _uow.SmsTemplates.AnyAsync(name, cancellationToken);
}
namespace Reservation.Application.SmsTemplates.Commands.UpdateSmsTemplate;

public sealed class UpdateSmsTemplateCommandValidator : AbstractValidator<UpdateSmsTemplateCommandRequest>
{
    public UpdateSmsTemplateCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithMessage("نام نباید خالی باشد لطفا آدرس")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست لطفا درست وارد کنید");

        RuleFor(r => r.Description)
            .NotEmpty().WithMessage("توضیحات نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمات معتبر نیست");
    }
}
namespace Reservation.Application.SmsCredits.Commands.CreateSmsCredit;

public sealed class CreateSmsCreditCommandValidator : AbstractValidator<CreateSmsCreditCommandRequest>
{
    public CreateSmsCreditCommandValidator()
    {
        RuleFor(r => r.Count)
            .Must(InvalidSmsCount).WithMessage("تعداد پیامک ها باید بیشتر از صفر باشد");
    }

    private bool InvalidSmsCount(int count)
        => count > 0;
}
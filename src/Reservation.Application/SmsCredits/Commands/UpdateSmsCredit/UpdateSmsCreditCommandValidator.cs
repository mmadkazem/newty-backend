namespace Reservation.Application.SmsCredits.Commands.UpdateSmsCredit;

public sealed class UpdateSmsCreditCommandValidator : AbstractValidator<UpdateSmsCreditCommandRequest>
{
    public UpdateSmsCreditCommandValidator()
    {
                RuleFor(r => r.Count)
            .Must(InvalidSmsCount).WithMessage("تعداد پیامک ها باید بیشتر از صفر باشد");
    }

    private bool InvalidSmsCount(int count)
        => count > 0;
}
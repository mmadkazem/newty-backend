namespace Reservation.Application.Businesses.Commands.AddBusinessPoint;

public sealed class AddBusinessPointCommandValidator : AbstractValidator<AddBusinessPointCommandRequest>
{
    public AddBusinessPointCommandValidator()
    {
        RuleFor(r => r.Rate)
            .Must(MaximumLengthValidator).WithMessage("امتیاز باید کمتر از 5 باشد")
            .Must(MinimumLengthValidator).WithMessage("امتیاز باید بیشتر از 0 باشد");
    }

    private bool MinimumLengthValidator(int rate)
        => rate > 0;

    private bool MaximumLengthValidator(int rate)
        => rate < 5;
}
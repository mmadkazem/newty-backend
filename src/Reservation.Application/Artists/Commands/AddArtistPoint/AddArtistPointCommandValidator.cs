namespace Reservation.Application.Artists.Commands.AddArtistPoint;

public sealed class AddArtistPointCommandValidator : AbstractValidator<AddArtistPointCommandRequest>
{
    public AddArtistPointCommandValidator()
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
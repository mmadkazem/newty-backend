namespace Reservation.Application.Artists.Commands.UpdateArtist;

public sealed class UpdateArtistCommandValidator : AbstractValidator<UpdateArtistCommandRequest>
{
    public UpdateArtistCommandValidator()
    {
        RuleFor(b => b.CoverImagePath)
            .NotEmpty().WithMessage("نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست");

        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("نام کسب و کار شما نمی تواند خالی باشد")
            .MaximumLength(50).WithMessage("نام کسب و کار شما نمی تواند بیشتر از 50 کاراکتر باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست");

        RuleFor(r => r.Description)
            .NotEmpty().WithMessage("توضیحات نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمات معتبر نیست");
    }
}
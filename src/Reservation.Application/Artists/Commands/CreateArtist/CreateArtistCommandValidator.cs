namespace Reservation.Application.Artists.Commands.CreateArtist;

public sealed class CreateArtistCommandValidator : AbstractValidator<CreateArtistCommandRequest>
{
    private readonly IUnitOfWork _uow;
    public CreateArtistCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;
        RuleFor(b => b.CoverImagePath)
            .NotEmpty().WithMessage("نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست");

        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("نام کسب و کار شما نمی تواند خالی باشد")
            .MaximumLength(50).WithMessage("نام کسب و کار شما نمی تواند بیشتر از 50 کاراکتر باشد")
            .MustAsync(ArtistNameAlreadyExist).WithMessage("این آرتیست وجود دارد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست");

        RuleFor(r => r.Description)
            .NotEmpty().WithMessage("توضیحات نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمات معتبر نیست");
    }

    private async Task<bool> ArtistNameAlreadyExist(string name, CancellationToken cancellationToken)
        => !await _uow.Businesses.AnyAsyncArtist(name, cancellationToken);
}
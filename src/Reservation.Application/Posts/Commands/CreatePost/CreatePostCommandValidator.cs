namespace Reservation.Application.Posts.Commands.CreatePost;

public sealed class CreatePostCommandValidator : AbstractValidator<CreatePostCommandRequest>
{
    private readonly IUnitOfWork _uow;
    public CreatePostCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("عنوان نباید خالی باشد لطفا")
            .MustAsync(AlreadyExistTitle).WithMessage("این عنوان وجود دارد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست لطفا درست وارد کنید");

        RuleFor(r => r.Description)
            .NotEmpty().WithMessage("توضیحات نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمات معتبر نیست");

        RuleFor(r => r.CoverImagePath)
            .NotEmpty().WithMessage("آدرس نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست");
    }

    private async Task<bool> AlreadyExistTitle(string title, CancellationToken cancellationToken)
        => await _uow.Posts.AnyAsync(title, cancellationToken);
}
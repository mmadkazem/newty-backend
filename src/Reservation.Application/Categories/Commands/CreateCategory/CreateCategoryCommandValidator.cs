
namespace Reservation.Application.Categories.Commands.CreateCategory;


public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
{
    private readonly IUnitOfWork _uow;
    public CreateCategoryCommandValidator(IUnitOfWork uow)
    {
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("عنوان نباید خالی باشد لطفا آدرس")
            .MustAsync(AlreadyExistTitle).WithMessage("این عنوان وجود دارد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست لطفا درست وارد کنید");

        RuleFor(r => r.Description)
            .NotEmpty().WithMessage("توضیحات نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمات معتبر نیست");

        RuleFor(r => r.CoverImagePath)
            .NotEmpty().WithMessage("آدرس نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست");
        _uow = uow;
    }

    private async Task<bool> AlreadyExistTitle(string title, CancellationToken cancellationToken)
        => !await _uow.Categories.AnyAsync(title, cancellationToken);
}
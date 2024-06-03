namespace Reservation.Application.Categories.Commands.CreateSubCategory;


public class CreateSubCategoryCommandValidator : AbstractValidator<CreateSubCategoryCommandRequest>
{
    private readonly IUnitOfWork _uow;
    public CreateSubCategoryCommandValidator(IUnitOfWork uow)
    {
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("عنوان نباید خالی باشد")
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
        => !await _uow.Categories.AnyAsyncSunCategory(title, cancellationToken);
}
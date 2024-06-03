namespace Reservation.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommandRequest>
{
    public UpdateCategoryCommandValidator(IUnitOfWork uow)
    {
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("عنوان نباید خالی باشد لطفا آدرس")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست لطفا درست وارد کنید");

        RuleFor(r => r.Description)
            .NotEmpty().WithMessage("توضیحات نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمات معتبر نیست");

        RuleFor(r => r.CoverImagePath)
            .NotEmpty().WithMessage("آدرس نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست");
    }
}

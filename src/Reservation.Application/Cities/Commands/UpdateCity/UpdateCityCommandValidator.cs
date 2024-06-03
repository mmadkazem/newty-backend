namespace Reservation.Application.Cities.Commands.UpdateCity;

public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommandRequest>
{
    public UpdateCityCommandValidator(IUnitOfWork uow)
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("نام نباید خالی باشد")
            .MaximumLength(50).WithMessage("نام شهر نباید بیشتر از 50 تا کلمه باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست لطفا درست وارد کنید");

        RuleFor(b => b.State)
            .NotEmpty().WithMessage("استان نباید خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست لطفا درست وارد کنید");
    }
}
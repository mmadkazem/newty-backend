namespace Reservation.Application.Cities.Commands.CreateCity;

public class CreateCityCommandValidator : AbstractValidator<CreateCityCommandRequest>
{
    private readonly IUnitOfWork _uow;
    public CreateCityCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("نام نباید خالی باشد")
            .MustAsync(AlreadyExistCity).WithMessage("این شهر وجود دارد")
            .MaximumLength(50).WithMessage("نام شهر نباید بیشتر از 50 تا کلمه باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست لطفا درست وارد کنید");

    }

    private async Task<bool> AlreadyExistCity(string city, CancellationToken cancellationToken)
        => !await _uow.Cities.AnyAsync(city, cancellationToken);
}
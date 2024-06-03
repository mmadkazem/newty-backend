namespace Reservation.Application.Businesses.Commands.RegisterBusiness;


public class RegisterBusinessCommandValidator : AbstractValidator<RegisterBusinessCommandRequest>
{
    private readonly IUnitOfWork _uow;
    public RegisterBusinessCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;
        RuleFor(b => b.PhoneNumber)
            .NotEmpty().WithMessage("شماره همراه نمی تواند خالی باشد")
            .MustAsync(AlreadyExistPhoneNumber).WithMessage("این شماره تلفن وجود دارد")
            .Must(StringUtils.IsValidPhone).WithMessage("شماره همراه اشتباه است");

        RuleFor(r => r.City)
            .NotEmpty().WithMessage("شهر نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست")
            .MustAsync(IsNotExistCity).WithMessage("این شهر فعلا پشتیبانی نمی شود");
    }
    private async Task<bool> IsNotExistCity(string city, CancellationToken cancellationToken)
        => await _uow.Cities.AnyAsync(city, cancellationToken);
    private async Task<bool> AlreadyExistPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        => !await _uow.Businesses.AnyAsync(phoneNumber, cancellationToken);
}
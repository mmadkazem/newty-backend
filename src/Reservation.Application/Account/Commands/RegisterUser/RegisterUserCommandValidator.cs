namespace Reservation.Application.Account.Commands.RegisterUser;

public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommandRequest>
{
    private readonly IUnitOfWork _uow;
    public RegisterUserCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;
        RuleFor(r => r.PhoneNumber)
            .NotEmpty().WithMessage("شماره همراه نمی تواند خالی باشد")
            .MustAsync(AlreadyExistPhoneNumber).WithMessage("این شماره تلفن وجود دارد")
            .Must(StringUtils.IsValidPhone).WithMessage("شماره همراه اشتباه است");

        RuleFor(r => r.FullName)
            .NotEmpty().WithMessage("نام و نام خانوادگی نمی تواند خالی باشد")
            .MaximumLength(16).WithMessage("نام شما نمی تواند بیشتر از 50 کاراکتر باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست");
    }

    private async Task<bool> AlreadyExistPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        => !await _uow.Users.AnyAsync(phoneNumber, cancellationToken);
}
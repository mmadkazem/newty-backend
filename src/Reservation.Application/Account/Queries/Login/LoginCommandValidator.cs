namespace Reservation.Application.Account.Queries.Login;


public class LoginCommandValidator : AbstractValidator<LoginCommandRequest>
{
    public LoginCommandValidator()
    {
        RuleFor(r => r.PhoneNumber)
            .NotEmpty().WithMessage("شماره همراه نمی تواند خالی باشد")
            .Must(StringUtils.IsValidPhone).WithMessage("شماره همراه اشتباه است");
    }
}
namespace Reservation.Application.Account.Queries.Login;


public class LoginQueryValidator : AbstractValidator<LoginQueryRequest>
{
    public LoginQueryValidator()
    {
        RuleFor(r => r.PhoneNumber)
            .NotEmpty().WithMessage("شماره همراه نمی تواند خالی باشد")
            .Must(StringUtils.IsValidPhone).WithMessage("شماره همراه اشتباه است");
    }
}
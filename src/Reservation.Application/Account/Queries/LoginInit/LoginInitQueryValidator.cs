namespace Reservation.Application.Account.Queries.LoginInit;


public class LoginInitQueryValidator : AbstractValidator<LoginInitQueryRequest>
{
    public LoginInitQueryValidator()
    {
        RuleFor(r => r.PhoneNumber)
            .NotEmpty().WithMessage("شماره همراه نمی تواند خالی باشد")
            .Must(StringUtils.IsValidPhone).WithMessage("شماره همراه اشتباه است");
    }
}
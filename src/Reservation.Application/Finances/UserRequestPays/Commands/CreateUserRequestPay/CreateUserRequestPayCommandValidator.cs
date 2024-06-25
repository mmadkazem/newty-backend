namespace Reservation.Application.Finances.UserRequestPays.Commands.CreateUserRequestPay;

public sealed class CreateUserRequestPayCommandValidator : AbstractValidator<CreateUserRequestPayCommandRequest>
{
    public CreateUserRequestPayCommandValidator()
    {
        RuleFor(r => r.Amount)
            .Must(InvalidPrice).WithMessage("مبلغ باید بیشتر از 0 باشد");
    }

    private bool InvalidPrice(int price)
        => price > 0;
}
namespace Reservation.Application.Finances.BusinessRequestPays.Commands.CreateBusinessRequestPay;

public class CreateBusinessRequestPayCommandValidator : AbstractValidator<CreateBusinessRequestPayCommandRequest>
{
    public CreateBusinessRequestPayCommandValidator()
    {
        RuleFor(r => r.Amount)
            .Must(InvalidPrice).WithMessage("مبلغ باید بیشتر از 0 باشد");
    }

    private bool InvalidPrice(int price)
        => price > 0;
}
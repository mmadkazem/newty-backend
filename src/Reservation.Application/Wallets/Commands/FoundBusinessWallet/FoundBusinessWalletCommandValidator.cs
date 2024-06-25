namespace Reservation.Application.Wallets.Commands.FoundBusinessWallet;

public sealed class FoundBusinessWalletCommandValidator : AbstractValidator<FoundBusinessWalletCommandRequest>
{
    public FoundBusinessWalletCommandValidator()
    {
        RuleFor(r => r.Credit)
            .Must(InvalidSmsCount).WithMessage("مبلغ شارژ باید بیشتر از صفر باشد");
    }

    private bool InvalidSmsCount(decimal credit)
        => credit > 0;
}
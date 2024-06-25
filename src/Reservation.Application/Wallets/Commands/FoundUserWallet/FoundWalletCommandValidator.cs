namespace Reservation.Application.Wallets.Commands.FoundUserWallet;

public sealed class FoundUserWalletCommandValidator : AbstractValidator<FoundUserWalletCommandRequest>
{
    public FoundUserWalletCommandValidator()
    {
        RuleFor(r => r.Credit)
            .Must(InvalidSmsCount).WithMessage("مبلغ شارژ باید بیشتر از صفر باشد");
    }

    private bool InvalidSmsCount(decimal credit)
        => credit > 0;
}
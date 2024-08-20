namespace Reservation.Application.Wallets.Commands.WithdrawBusinessWallet;

public sealed class WithdrawBusinessWalletCommandValidator : AbstractValidator<WithdrawBusinessWalletCommandRequest>
{
    public WithdrawBusinessWalletCommandValidator()
    {
        RuleFor(r => r.Amount)
            .Must(InvalidSmsCount).WithMessage("مبلغ برداشت باید بیشتر از صفر باشد");
    }

    private bool InvalidSmsCount(decimal credit)
        => credit > 0;
}
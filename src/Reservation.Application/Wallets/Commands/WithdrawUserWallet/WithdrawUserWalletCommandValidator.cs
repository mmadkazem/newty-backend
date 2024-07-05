namespace Reservation.Application.Wallets.Commands.WithdrawUserWallet;

public sealed class WithdrawUserWalletCommandValidator : AbstractValidator<WithdrawUserWalletCommandRequest>
{
    public WithdrawUserWalletCommandValidator()
    {
        RuleFor(r => r.Amount)
            .Must(InvalidSmsCount).WithMessage("مبلغ برداشت باید بیشتر از صفر باشد");
    }

    private bool InvalidSmsCount(decimal credit)
        => credit > 0;
}
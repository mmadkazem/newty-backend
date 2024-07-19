namespace Reservation.Application.TransferFees.Commands.UpdateTransferFee;


public sealed record UpdateTransferFeeCommandRequest(int Percent) : IRequest;


public sealed class UpdateTransferFeeCommandValidator : AbstractValidator<UpdateTransferFeeCommandRequest>
{
    public UpdateTransferFeeCommandValidator()
    {
        RuleFor(b => b.Percent)
            .Must(IsValidPercent).WithMessage("لطفا درصد وارد کنید");
    }

    private bool IsValidPercent(int percent)
        => percent >= 0 && percent <= 100;
}
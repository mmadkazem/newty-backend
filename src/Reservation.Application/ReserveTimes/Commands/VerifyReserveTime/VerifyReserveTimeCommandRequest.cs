namespace Reservation.Application.ReserveTimes.Commands.VerifyReserveTime;

public sealed record VerifyReserveTimeCommandRequest(Guid ReserveTimeId, string Authority) : IRequest<string>;

public sealed class VerifyReserveTimeCommandHandler(IUnitOfWork uow, IPaymentProvider paymentProvider)
    : IRequestHandler<VerifyReserveTimeCommandRequest, string>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IPaymentProvider _paymentProvider = paymentProvider;

    public async Task<string> Handle(VerifyReserveTimeCommandRequest request, CancellationToken cancellationToken)
    {
        var reserveTime = await _uow.ReserveTimes.FindAsyncByIdAndAuthority(request.ReserveTimeId, request.Authority, cancellationToken)
            ?? throw new BusinessRequestPayNotFoundException();

        var result = await _paymentProvider.Verification(request.Authority, reserveTime.UserRequestPay.Amount);
        if (result.Status == PaymentStatus.Error)
        {
            return VerifyReserveTimeCommandResponse.UnSuccessRedirectUrl;
        }
        reserveTime.State = ReserveState.Waiting;
        reserveTime.TransactionReceipt.State = TransactionState.Waiting;
        reserveTime.TransactionSender.State = TransactionState.Waiting;
        await _uow.SaveChangeAsync(cancellationToken);

        return VerifyReserveTimeCommandResponse.SuccessRedirectUrl;

    }
}

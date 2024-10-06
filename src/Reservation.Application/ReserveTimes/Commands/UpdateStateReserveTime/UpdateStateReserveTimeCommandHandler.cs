namespace Reservation.Application.ReserveTimes.Commands.UpdateStateReserveTime;

/// <summary>
/// Handles the updating of the state of a reserved time (e.g., Cancelled, Confirmed).
/// This class manages business rules, payments, and wallet transactions based on the
/// user's request and role (User or Business).
/// </summary>
public sealed class UpdateStateReserveTimeReceiptCommandHandler(IUnitOfWork uow, IFinishReserveTimeJob finishReserveTimeJob)
    : IRequestHandler<UpdateStateReserveTimeReceiptCommandRequest, UpdateStateReserveTimeReceiptCommandResponse>
{
    private readonly IUnitOfWork _uow = uow;
    private readonly IFinishReserveTimeJob _finishReserveTimeJob = finishReserveTimeJob;

    /// <summary>
    /// Main method for handling the update request.
    /// Based on the incoming request, it checks the role of the user and updates
    /// the reservation's state (Cancelled, Confirmed) by following the business rules.
    /// </summary>
    public async Task<UpdateStateReserveTimeReceiptCommandResponse> Handle(UpdateStateReserveTimeReceiptCommandRequest request, CancellationToken cancellationToken)
    {
        var reserveTime = await GetReserveTimeOrThrow(request.Id, cancellationToken);

        // Validate access based on the user's role (User or Business)
        ValidateUserAccess(request, reserveTime);

        // Process cancellation request
        if (request.State == ReserveState.Cancelled)
        {
            return await HandleCancellationAsync(reserveTime, request, cancellationToken);
        }

        // Process confirmation request
        if (request.State == ReserveState.Confirmed)
        {
            return await HandleConfirmationAsync(reserveTime, request, cancellationToken);
        }

        return new();
    }

    /// <summary>
    /// Retrieves the reserve time entity from the database or throws an exception if not found.
    /// </summary>
    private async Task<ReserveTimeReceipt> GetReserveTimeOrThrow(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.ReserveTimes.FindAsyncIncludeTransaction(id, cancellationToken)
            ?? throw new ReserveTimeNotFoundException();
    }

    /// <summary>
    /// Validates whether the caller has the right access based on their role.
    /// Throws an exception if the caller is not authorized.
    /// </summary>
    private void ValidateUserAccess(UpdateStateReserveTimeReceiptCommandRequest request, ReserveTimeReceipt reserveTime)
    {
        bool isUserAccess = reserveTime.User.Id == request.CallId && request.Role == Role.User;
        bool isBusinessAccess = reserveTime.BusinessReceipt.Id == request.CallId && request.Role == Role.Business;

        if (!isUserAccess && !isBusinessAccess)
        {
            throw new DotAccessReserveTimeException();
        }
    }

    /// <summary>
    /// Handles the cancellation process of a reservation.
    /// Checks business rules, processes refunds, and updates reservation state.
    /// </summary>
    private async Task<UpdateStateReserveTimeReceiptCommandResponse> HandleCancellationAsync(ReserveTimeReceipt reserveTime, UpdateStateReserveTimeReceiptCommandRequest request, CancellationToken cancellationToken)
    {
        // Ensure cancellation is within allowed time and that business allows cancellations
        if (IsTooLateToCancel(reserveTime))
        {
            throw new TimePassedCannotCancelException();
        }

        if (!reserveTime.BusinessReceipt.IsCancelReserveTime)
        {
            throw new BusinessCannotBeCanceledException();
        }

        // Process direct payment cancellation (refund logic)
        if (reserveTime.Type == PaymentType.Direct)
        {
            await ProcessDirectPaymentCancellation(reserveTime, cancellationToken);
        }
        else
        {
            UpdateReserveTimeState(reserveTime, ReserveState.Cancelled);
            await _uow.SaveChangeAsync(cancellationToken);
        }

        return new(ReserveTimeSuccessMessage.UpdatedCancelState);
    }

    /// <summary>
    /// Checks if the cancellation request is too late.
    /// </summary>
    private bool IsTooLateToCancel(ReserveTimeReceipt reserveTime)
    {
        return DateTime.Now.AddDays(1) >= reserveTime.TotalStartDate;
    }

    /// <summary>
    /// Processes a direct payment cancellation, refunding the user and deducting the admin fee.
    /// </summary>
    private async Task ProcessDirectPaymentCancellation(ReserveTimeReceipt reserveTime, CancellationToken cancellationToken)
    {
        var userWallet = await GetUserWallet(reserveTime.User.Id, cancellationToken);
        var adminWallet = await _uow.Wallets.FindAsyncAdminWallet(cancellationToken)!;
        var transferFee = await _uow.TransferFees.FindAsync(cancellationToken)!;

        // Refund user and transfer fee to admin
        ProcessRefund(userWallet, reserveTime.UserRequestPay.Amount, transferFee, adminWallet);

        UpdateReserveTimeState(reserveTime, ReserveState.Cancelled);
        await _uow.SaveChangeAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves the user's wallet or throws an exception if not found.
    /// </summary>
    private async Task<Wallet> GetUserWallet(Guid userId, CancellationToken cancellationToken)
    {
        return await _uow.Wallets.FindAsyncByUserId(userId, cancellationToken)
            ?? throw new WalletNotFoundException();
    }

    /// <summary>
    /// Processes the refund and admin fee deduction.
    /// </summary>
    private void ProcessRefund(Wallet userWallet, decimal amount, TransferFee transferFee, Wallet adminWallet)
    {
        userWallet.Credit += amount;
        var feeAmount = transferFee.Percent * amount / 100;
        userWallet.Credit -= feeAmount;
        adminWallet.Credit += feeAmount;
    }

    /// <summary>
    /// Handles the confirmation process of a reservation.
    /// Checks business rules, manages wallet transactions, and updates reservation state.
    /// </summary>
    private async Task<UpdateStateReserveTimeReceiptCommandResponse> HandleConfirmationAsync(ReserveTimeReceipt reserveTime, UpdateStateReserveTimeReceiptCommandRequest request, CancellationToken cancellationToken)
    {
        // Ensure only business can confirm the reservation, not the user
        if (request.Role == Role.User)
        {
            throw new UserNotAccessStateIsConfirmedException();
        }

        var userWallet = await GetUserWallet(reserveTime.User.Id, cancellationToken);
        var businessWallet = await GetBusinessWallet(reserveTime.BusinessReceiptId, cancellationToken);

        // Handle direct payment confirmation
        if (reserveTime.Type == PaymentType.Direct)
        {
            await ProcessDirectPaymentConfirmation(reserveTime, businessWallet, cancellationToken);
        }
        else
        {
            await ProcessNonDirectPaymentConfirmation(reserveTime, userWallet, businessWallet, cancellationToken);
        }

        return new(ReserveTimeSuccessMessage.UpdatedConfirmState);
    }

    /// <summary>
    /// Retrieves the business wallet or throws an exception if not found.
    /// </summary>
    private async Task<Wallet> GetBusinessWallet(Guid businessId, CancellationToken cancellationToken)
    {
        return await _uow.Wallets.FindAsyncByBusinessId(businessId, cancellationToken)
            ?? throw new WalletNotFoundException();
    }

    /// <summary>
    /// Processes direct payment confirmation, transferring money to the business and deducting admin fees.
    /// </summary>
    private async Task ProcessDirectPaymentConfirmation(ReserveTimeReceipt reserveTime, Wallet businessWallet, CancellationToken cancellationToken)
    {
        var adminWallet = await _uow.Wallets.FindAsyncAdminWallet(cancellationToken)!;
        var transferFee = await _uow.TransferFees.FindAsync(cancellationToken)!;

        businessWallet.Credit += reserveTime.UserRequestPay.Amount;
        var feeAmount = transferFee.Percent * reserveTime.UserRequestPay.Amount / 100;
        businessWallet.Credit -= feeAmount;
        adminWallet.Credit += feeAmount;

        MarkPaymentComplete(reserveTime);
        await _uow.SaveChangeAsync(cancellationToken);
    }

    /// <summary>
    /// Handles non-direct payment confirmation, deducting from the user's wallet and transferring to the business.
    /// </summary>
    private async Task ProcessNonDirectPaymentConfirmation(ReserveTimeReceipt reserveTime, Wallet userWallet, Wallet businessWallet, CancellationToken cancellationToken)
    {
        if (userWallet.Credit < reserveTime.TransactionReceipt.Amount)
        {
            throw new BalanceInsufficientException();
        }

        userWallet.Credit -= reserveTime.TransactionReceipt.Amount;
        businessWallet.Credit += reserveTime.TransactionReceipt.Amount;

        MarkPaymentComplete(reserveTime);
        await _uow.SaveChangeAsync(cancellationToken);
        _finishReserveTimeJob.Execute(reserveTime.Id, reserveTime.TotalEndDate.AddMinutes(2));
    }

    /// <summary>
    /// Marks the reservation and related transactions as complete and updates their states.
    /// </summary>
    private void MarkPaymentComplete(ReserveTimeReceipt reserveTime)
    {
        reserveTime.IsPay = true;
        reserveTime.UserRequestPay.IsPay = true;
        UpdateReserveTimeState(reserveTime, ReserveState.Confirmed);
    }

    /// <summary>
    /// Updates the state of the reservation and its transactions (e.g., Cancelled or Confirmed).
    /// </summary>
    private void UpdateReserveTimeState(ReserveTimeReceipt reserveTime, ReserveState state)
    {
        reserveTime.State = state;
        reserveTime.TransactionReceipt.State = state == ReserveState.Cancelled ? TransactionState.Cancelled : TransactionState.Confirmed;
        reserveTime.TransactionSender.State = state == ReserveState.Cancelled ? TransactionState.Cancelled : TransactionState.Confirmed;
        reserveTime.ModifiedOn = DateTime.Now;
    }
}
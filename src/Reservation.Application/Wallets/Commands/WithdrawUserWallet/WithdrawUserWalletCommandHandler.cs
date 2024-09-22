namespace Reservation.Application.Wallets.Commands.WithdrawUserWallet;

// public sealed class WithdrawUserWalletCommandHandler(IUnitOfWork uow) : IRequestHandler<WithdrawUserWalletCommandRequest>
// {
//     private readonly IUnitOfWork _uow = uow;

//     public async Task Handle(WithdrawUserWalletCommandRequest request, CancellationToken cancellationToken)
//     {
//         var wallet = await _uow.Wallets.FindAsyncByUserId(request.UserId, cancellationToken)
//             ?? throw new WalletNotFoundException();

//         if (wallet.Credit - request.Amount < 0)
//         {
//             throw new BalanceInsufficientException();
//         }
//         wallet.Credit -= request.Amount;
//         wallet.Transactions.Add(new() { Amount = request.Amount, Type = TransactionType.Withdraw });

//         await _uow.SaveChangeAsync(cancellationToken);
//     }
// }
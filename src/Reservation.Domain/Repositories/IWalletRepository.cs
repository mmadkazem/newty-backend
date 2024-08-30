namespace Reservation.Domain.Repositories;

public interface IWalletRepository
{
    void AddTransaction(Transaction transaction);
    Task<Wallet> FindAsyncByBusinessId(Guid businessId, CancellationToken cancellationToken = default);
    Task<Wallet> FindAsyncByUserId(Guid userId, CancellationToken cancellationToken = default);
    Task<Guid> FindAsyncUserWalletId(Guid userId, CancellationToken cancellationToken);
    Task<Guid> FindAsyncBusinessWalletId(Guid userId, CancellationToken cancellationToken);
    Task<IResponse> GetUserWallet(Guid userId, CancellationToken cancellationToken);
    Task<IResponse> GetBusinessWallet(Guid businessId, CancellationToken cancellationToken);
    Task<IEnumerable<IResponse>> GetTransactions(int page, int size, Guid walletId, CancellationToken cancellationToken);
}
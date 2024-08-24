namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class WalletRepository(NewtyDbContext context) : IWalletRepository
{
    private readonly NewtyDbContext _context = context;

    public void AddTransaction(Transaction transaction)
        => _context.Transactions.Add(transaction);

    public async Task<Wallet> FindAsyncByBusinessId(Guid businessId, CancellationToken cancellationToken)
        => await _context.Businesses.AsQueryable()
                                .Select(u => u.Wallet)
                                .FirstOrDefaultAsync(b => b.Id == businessId, cancellationToken);

    public async Task<Wallet> FindAsyncByUserId(Guid userId, CancellationToken cancellationToken)
        => await _context.Users.AsQueryable()
                                .Select(u => u.Wallet)
                                .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);

    public async Task<Guid> FindAsyncUserWalletId(Guid userId, CancellationToken cancellationToken)
        => await _context.Users.AsQueryable()
                                .Where(u => u.Id == userId)
                                .Select(u => u.Wallet.Id)
                                .FirstOrDefaultAsync(cancellationToken);

    public async Task<IResponse> GetUserWallet(Guid userId, CancellationToken cancellationToken)
        => await _context.Users.AsQueryable()
                                .AsNoTracking()
                                .Where(u => u.Id == userId)
                                .Select(u => new GetUserWalletQueryResponse
                                (
                                    u.Wallet.Id,
                                    u.Wallet.Credit
                                )).FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<IResponse>> GetTransactions(int page, Guid walletId, CancellationToken cancellationToken)
        => await _context.Transactions.AsQueryable()
                                    .AsNoTracking()
                                    .Where(w => w.Wallet.Id == walletId)
                                    .Select(w => new GetWalletTransactionsQueryResponse
                                    (
                                        w.Id,
                                        w.CreatedOn,
                                        w.Amount,
                                        w.Type,
                                        w.State
                                    ))
                                    .Skip((page - 1) * 25)
                                    .Take(25)
                                    .ToListAsync(cancellationToken);

    public async Task<IResponse> GetBusinessWallet(Guid businessId, CancellationToken cancellationToken)
        => await _context.Businesses.AsQueryable()
                                .AsNoTracking()
                                .Where(b => b.Id == businessId)
                                .Select(b => new GetBusinessWalletQueryResponse
                                (
                                    b.Wallet.Id,
                                    b.Wallet.Credit
                                )).FirstOrDefaultAsync(cancellationToken);

    public async Task<Guid> FindAsyncBusinessWalletId(Guid businessId, CancellationToken cancellationToken)
        => await _context.Businesses.AsQueryable()
                                .Where(u => u.Id == businessId)
                                .Select(u => u.Wallet.Id)
                                .FirstOrDefaultAsync(cancellationToken);
}
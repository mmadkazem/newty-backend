namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class TransferFeeRepository(NewtyDbContext context) : ITransferFeeRepository
{
    private readonly NewtyDbContext _context = context;

    public async Task<TransferFee> FindAsync(CancellationToken cancellationToken)
        => await _context.TransferFees.AsQueryable()
                                        .FirstOrDefaultAsync(cancellationToken);

    public async Task<IResponse> Get(CancellationToken cancellationToken)
        => await _context.TransferFees.AsQueryable()
                                        .Select(s => new GetTransferFeeQueryResponse
                                        (
                                            s.Percent,
                                            s.ModifiedOn
                                        ))
                                        .FirstOrDefaultAsync(cancellationToken);
}
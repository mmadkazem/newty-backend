namespace Reservation.Infrastructure.Persistance.Repositories;


public sealed class TransferFeeRepository(NewtyDbContext context, NewtyDbContextCommand contextCommand) : ITransferFeeRepository
{
    private readonly NewtyDbContext _context = context;
    private readonly NewtyDbContextCommand _contextCommand = contextCommand;

    public async Task<TransferFee> FindAsync(CancellationToken cancellationToken)
        => await _contextCommand.TransferFees.AsQueryable()
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
namespace Reservation.Domain.Repositories;


public interface ITransferFeeRepository
{
    Task<TransferFee> FindAsync(CancellationToken cancellationToken = default);
    Task<IResponse> Get(CancellationToken cancellationToken = default);
}
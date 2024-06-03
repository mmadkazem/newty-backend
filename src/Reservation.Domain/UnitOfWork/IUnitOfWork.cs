
namespace Reservation.Domain.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    ICityRepository Cities { get; }
    IBusinessRepository Businesses { get; }
    ICategoryRepository Categories { get; }
    Task SaveChangeAsync(CancellationToken cancellationToken = default);
}
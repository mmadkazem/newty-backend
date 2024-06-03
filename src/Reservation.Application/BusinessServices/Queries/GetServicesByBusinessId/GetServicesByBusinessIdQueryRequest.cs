namespace Reservation.Application.BusinessServices.Queries.GetServicesByBusinessId;


public record GetServicesByBusinessIdQueryRequest(Guid BusinessId) : IRequest<IEnumerable<IResponse>>;

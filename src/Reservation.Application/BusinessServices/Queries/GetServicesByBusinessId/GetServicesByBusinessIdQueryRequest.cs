namespace Reservation.Application.BusinessServices.Queries.GetServicesByBusinessId;


public record GetServicesByBusinessIdQueryRequest(int Page, int Size, Guid BusinessId) : IRequest<Response>;
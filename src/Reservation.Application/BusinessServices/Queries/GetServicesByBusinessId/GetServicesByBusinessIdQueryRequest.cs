namespace Reservation.Application.BusinessServices.Queries.GetServicesByBusinessId;


public record GetServicesByBusinessIdQueryRequest(int Page, Guid BusinessId) : IRequest<IEnumerable<IResponse>>
{
    public static GetServicesByBusinessIdQueryRequest Create(int page, Guid businessId)
        => new(page, businessId);
}

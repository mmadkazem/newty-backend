namespace Reservation.Application.BusinessServices.Queries.GetServicesByBusinessId;

public record GetServicesByBusinessIdQueryResponse
(
    Guid Id,
    string Name,
    int Price,
    Time Time,
    bool Active
) : IResponse;
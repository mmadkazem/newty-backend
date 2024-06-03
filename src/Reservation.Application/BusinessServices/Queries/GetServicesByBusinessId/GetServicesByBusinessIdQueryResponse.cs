namespace Reservation.Application.BusinessServices.Queries.GetServicesByBusinessId;

public record GetServicesByBusinessIdQueryResponse
(
    Guid Id,
    string Name,
    int Price,
    TimeOnly Time,
    bool Active
) : IResponse;
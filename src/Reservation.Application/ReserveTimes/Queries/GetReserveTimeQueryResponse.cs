namespace Reservation.Application.ReserveTimes.Queries;

public record GetReserveTimeQueryResponse
(
    Guid Id,
    DateTime TotalStartDate,
    DateTime TotalEndDate,
    int TotalPrice,
    Guid UserId,
    IEnumerable<ReserveItemsResponse> ReserveItems
) : IResponse;

public record GetReserveTimeSenderQueryResponse
(
    Guid Id,
    DateTime TotalStartDate,
    DateTime TotalEndDate,
    int TotalPrice,
    Guid UserId,
    string State,
    IEnumerable<ReserveItemsResponse> ReserveItems
) : IResponse;

public record ReserveItemsResponse
(
    Guid Id,
    DateTime StartDate,
    DateTime EndDate,
    int Price,
    Guid ServiceId
);

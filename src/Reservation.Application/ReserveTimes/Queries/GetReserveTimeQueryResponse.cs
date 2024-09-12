namespace Reservation.Application.ReserveTimes.Queries;

public record GetReserveTimeDetailQueryResponse
(
    Guid Id,
    DateTime TotalStartDate,
    DateTime TotalEndDate,
    int TotalPrice,
    Guid? UserId,
    string State,
    IEnumerable<ReserveItemsResponse> ReserveItems
) : IResponse;

public sealed record GetReserveTimeUserQueryResponse
(
    Guid Id,
    DateTime TotalStartDate,
    DateTime TotalEndDate,
    string BusinessName,
    string BusinessAddress,
    string BusinessCoverImagePath
) : IResponse;

public sealed record GetReserveTimeBusinessReceiptQueryResponse
(
    Guid Id,
    DateTime TotalStartDate,
    DateTime TotalEndDate,
    string UserFullName
) : IResponse;

public record GetReserveTimeSenderByIdQueryResponse
(
    Guid Id,
    DateTime TotalStartDate,
    DateTime TotalEndDate,
    int TotalPrice,
    Guid BusinessReceiptId,
    string State,
    IEnumerable<ReserveItemsResponse> ReserveItems
) : IResponse;

public sealed record GetReserveTimeBusinessSenderQueryResponse
(
    Guid Id,
    DateTime TotalStartDate,
    DateTime TotalEndDate,
    string BusinessName,
    string BusinessAddress,
    string BusinessCoverImagePath
) : IResponse;

public record ReserveItemsResponse
(
    Guid Id,
    DateTime StartDate,
    DateTime EndDate,
    int Price,
    Guid ServiceId
);

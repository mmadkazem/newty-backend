namespace Reservation.Application.ReserveTimes.Queries;

public record GetReserveTimeDetailQueryResponse
(
    Guid Id,
    DateTime TotalStartDate,
    DateTime TotalEndDate,
    int TotalPrice,
    Guid? UserId,
    string State,
    bool Finished,
    bool BusinessTimeCancellation,
    IEnumerable<ReserveItemsResponse> ReserveItems
) : IResponse;

public sealed record GetReserveTimeUserQueryResponse
(
    Guid Id,
    DateTime TotalStartDate,
    DateTime TotalEndDate,
    string BusinessName,
    string BusinessAddress,
    string BusinessCoverImagePath,
    bool BusinessTimeCancellation
) : IResponse;

public sealed record GetReserveTimeBusinessReceiptQueryResponse
(
    Guid Id,
    DateTime TotalStartDate,
    DateTime TotalEndDate,
    string UserFullName,
    bool BusinessTimeCancellation
) : IResponse;

public record GetReserveTimeSenderByIdQueryResponse
(
    Guid Id,
    DateTime TotalStartDate,
    DateTime TotalEndDate,
    int TotalPrice,
    Guid BusinessReceiptId,
    string State,
    bool Finished,
    bool BusinessTimeCancellation,
    IEnumerable<ReserveItemsResponse> ReserveItems
) : IResponse;

public sealed record GetReserveTimeBusinessSenderQueryResponse
(
    Guid Id,
    DateTime TotalStartDate,
    DateTime TotalEndDate,
    string BusinessName,
    string BusinessAddress,
    string BusinessCoverImagePath,
    bool BusinessTimeCancellation
) : IResponse;

public record ReserveItemsResponse
(
    Guid Id,
    DateTime StartDate,
    DateTime EndDate,
    int Price,
    Guid ServiceId
);

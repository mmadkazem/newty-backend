
namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTimeSenderByState;

public record GetBusinessReserveTimeSenderByStateQueryRequest(int Page, ReserveState State, Guid BusinessId)
    : IRequest<IEnumerable<IResponse>>
{
    public static GetBusinessReserveTimeSenderByStateQueryRequest Create(int page, ReserveState state, Guid businessId)
        => new(page, state, businessId);
}

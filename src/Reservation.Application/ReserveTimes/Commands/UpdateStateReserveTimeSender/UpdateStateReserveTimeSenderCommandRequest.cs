
namespace Reservation.Application.ReserveTimes.Commands.UpdateStateReserveTimeSender;


public record UpdateStateReserveTimeSenderCommandRequest(Guid Id, Guid BusinessId, ReserveState State) : IRequest;

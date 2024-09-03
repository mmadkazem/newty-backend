namespace Reservation.Application.Artists.Commands.AddService;


public record AddServiceCommandRequest(Guid ArtistId, Guid ServiceId, Guid BusinessId) : IRequest;

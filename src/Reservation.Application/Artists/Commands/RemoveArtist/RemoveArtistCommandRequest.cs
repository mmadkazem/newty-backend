namespace Reservation.Application.Artists.Commands.RemoveArtist;



public sealed record RemoveArtistCommandRequest(Guid Id, Guid BusinessId) : IRequest;

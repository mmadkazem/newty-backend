namespace Reservation.Application.Posts.Commands.RemovePost;


public sealed record RemovePostCommandRequest(Guid Id, Guid BusinessId) : IRequest;

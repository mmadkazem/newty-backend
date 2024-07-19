namespace Reservation.Application.Categories.Commands.RemoveCategory;


public sealed record RemoveCategoryCommandRequest(Guid Id) : IRequest;

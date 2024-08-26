namespace Reservation.Application.Categories.Commands.RemoveCategory;


public sealed record RemoveCategoryCommandRequest(int Id) : IRequest;

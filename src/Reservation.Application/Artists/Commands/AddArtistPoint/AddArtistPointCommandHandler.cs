namespace Reservation.Application.Artists.Commands.AddArtistPoint;

public sealed class AddArtistPointCommandHandler(IUnitOfWork uow)
    : IRequestHandler<AddArtistPointCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(AddArtistPointCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _uow.Users.FindAsync(request.UserId, cancellationToken)
            ?? throw new UserNotFoundException();

        var artist = await _uow.Artists.FindAsyncByIncludePoints(request.ArtistId, cancellationToken)
            ?? throw new ArtistNotFoundException();

        artist.Average = await _uow.Artists.GetAveragePoints(request.ArtistId, cancellationToken);

        Point point = new()
        {
            Rate = request.Rate,
            User = user
        };

        artist.Points.Add(point);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}
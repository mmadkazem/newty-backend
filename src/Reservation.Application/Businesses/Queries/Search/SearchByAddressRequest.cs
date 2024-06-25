namespace Reservation.Application.Businesses.Queries.Search;

public record SearchBusinessRequest(int Page, string Key) : IRequest<IEnumerable<IResponse>>
{
    public static SearchBusinessRequest Create(int page, string key)
        => new(page, key);
}

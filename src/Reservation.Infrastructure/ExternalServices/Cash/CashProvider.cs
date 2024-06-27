namespace Reservation.Infrastructure.ExternalServices.Cash;


public sealed class CacheProvider(IDistributedCache cache) : ICacheProvider
{
    private readonly IDistributedCache _cache = cache;

    public async Task<T> GetAsync<T>(string key)
    {
        var data = await _cache.GetAsync(key);
        return JsonSerializer.Deserialize<T>(data);
    }

    public async Task SetAsync<T>(string key, T user)
    {
        var jsonData = JsonSerializer.Serialize(user);
        byte[] encodedJson = Encoding.UTF8.GetBytes(jsonData);

        var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromHours(1));

        await _cache.SetAsync(key, encodedJson, options);
    }
}
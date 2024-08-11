namespace Reservation.Infrastructure.ExternalServices.Cash;


public sealed class CacheProvider(IDistributedCache cache) : ICacheProvider
{
    private readonly IDistributedCache _cache = cache;

    public async Task<T> GetAsync<T>(string key, CancellationToken token)
    {
        var data = await _cache.GetAsync(key, token);
        return JsonSerializer.Deserialize<T>(data);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan expireTime, CancellationToken token)
    {
        var jsonData = JsonSerializer.Serialize(value);
        byte[] encodedJson = Encoding.UTF8.GetBytes(jsonData);

        var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(expireTime);

        await _cache.SetAsync(key, encodedJson, options, token);
    }

    public async Task RemoveAsync(string key, CancellationToken token)
    {
        await _cache.RemoveAsync(key, token);
    }
}
namespace Reservation.Application.ExternalServices.Cash;


public interface ICacheProvider
{
    Task SetAsync<T>(string key, T t, TimeSpan expireTime, CancellationToken token = default);
    Task<T> GetAsync<T>(string key, CancellationToken token = default);
    Task RemoveAsync(string key, CancellationToken token = default);
}

public record UserRegisterCacheVM(string Name, string PhoneNumber)
{
    public static string ToKey(string phoneNumber)
        => nameof(User) + "Register" + phoneNumber;
}
public record UserLoginCacheVM(Guid Id, string PhoneNumber, string OTPCode, bool IsFirst, string? Name = null)
{
    public static string ToKey(string phoneNumber)
        => nameof(User) + "Login" + phoneNumber;
}
public record BusinessRegisterCacheVM(string City, string PhoneNumber)
{
    public static string ToKey(string phoneNumber)
        => nameof(Business) + "Register" + phoneNumber;
}
public record BusinessLoginCacheVM(Guid Id, string PhoneNumber, string OTPCode, bool IsFirst, string? City = null)
{
    public static string ToKey(string phoneNumber)
        => nameof(Business) + "Login" + phoneNumber;
}
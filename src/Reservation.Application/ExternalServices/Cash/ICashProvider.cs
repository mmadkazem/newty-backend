namespace Reservation.Application.ExternalServices.Cash;


public interface ICacheProvider
{
    Task SetAsync<T>(string key, T t);
    Task<T> GetAsync<T>(string key);
}

public record UserCacheVM(string Name, string PhoneNumber, string OTPCode);
public record BusinessCacheVM(string City, string PhoneNumber, string OTPCode);
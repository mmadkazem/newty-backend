namespace Reservation.Share.Abstract.Helper;

public interface IResponse { }

public readonly record struct Response(bool IsDown, IEnumerable<IResponse> Data);
public readonly record struct Response<T>(bool IsDown, List<T> Data);
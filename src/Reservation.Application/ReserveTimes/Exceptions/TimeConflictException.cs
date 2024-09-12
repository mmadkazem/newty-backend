namespace Reservation.Application.ReserveTimes.Exceptions;


public sealed class BusinessTimeConflictException : NewtyBadRequestBaseException
{
    public BusinessTimeConflictException()
        : base("این وقت پر است لطفا وقت دیگری را انتخاب کنید") { }
}

public sealed class UserTimeConflictException : NewtyBadRequestBaseException
{
    public UserTimeConflictException()
        : base("با وقت خودتون تداخل دارد") { }
}
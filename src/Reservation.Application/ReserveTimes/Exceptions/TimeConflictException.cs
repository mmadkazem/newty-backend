namespace Reservation.Application.ReserveTimes.Exceptions;


public sealed class BusinessTimeConflictException : ReservationBadRequestBaseException
{
    public BusinessTimeConflictException()
        : base("این وقت این کسب و کار پر است دارد لطفا وقت دیگری را وارد کنید") { }
}

public sealed class UserTimeConflictException : ReservationBadRequestBaseException
{
    public UserTimeConflictException()
        : base("با وقت خودتون تداخل دارد") { }
}
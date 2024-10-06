namespace Reservation.Domain.Entities.Reserve;

public enum ReserveState : byte
{
    Waiting = 0,
    Confirmed = 1,
    Cancelled = 2,
    Created = 3,
}

public enum PaymentType : byte
{
    Wallet = 0,
    Direct = 1
}
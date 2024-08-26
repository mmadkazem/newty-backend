namespace Reservation.Domain.Entities.Admin;

public sealed class TransferFee : BaseClass<Guid>
{
    public int Percent { get; set; }
}
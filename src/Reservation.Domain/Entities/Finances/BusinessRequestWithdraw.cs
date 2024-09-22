namespace Reservation.Domain.Entities.Finances;

public sealed class BusinessRequestWithdraw : BaseClass<Guid>
{
    public decimal Amount { get; set; }
    public bool IsWithdraw { get; set; } = false;
    public DateTime WithdrawDate { get; set; }

    // Withdraw Request
    public Business Business { get; set; }
    public Guid BusinessId { get; set; }
}
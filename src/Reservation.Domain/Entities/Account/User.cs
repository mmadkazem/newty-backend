namespace Reservation.Domain.Entities.Account;

public class User : BaseClass
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }

    // User City
    public City City { get; set; }

    // User Wallet
    public Wallet Wallet { get; set; }
    public Guid WalletId { get; set; }

    // Business
    public ICollection<Business> Businesses { get; set; }

}
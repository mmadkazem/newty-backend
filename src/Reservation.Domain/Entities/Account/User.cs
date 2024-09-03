namespace Reservation.Domain.Entities.Account;

public class User : BaseClass<Guid>
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
    public bool IsActive { get; set; }

    // User City
    public City City { get; set; }

    //  User Wallet
    public Wallet Wallet { get; set; }

    // Business
    public ICollection<Business> Businesses { get; set; }

    // Validate User for using system
    public void IsValidate()
    {
        if (!IsActive)
        {
            throw new AccountNotActiveException();
        }
    }

}
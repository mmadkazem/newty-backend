namespace Reservation.Share.Abstract.Helper;


public abstract class BaseClass
{
    public Guid Id { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public DateTime ModifiedOn { get; set; }

    public DateTime DeletedOn { get; set; }
}
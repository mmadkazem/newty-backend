namespace Reservation.Domain.Entities.Admin;


public sealed class SmsPlan : BaseClass<Guid>
{
    public int SmsCount { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CoverImagePath { get; set; }
    public int Discount { get; set; }
}

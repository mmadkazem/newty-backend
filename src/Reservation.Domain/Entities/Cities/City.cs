namespace Reservation.Domain.Entities.Cities;


public class City : BaseClass
{
    public string FaName { get; set; }
    public string Key  { get; set; }
    public List<string> Alternatives  { get; set; }
}
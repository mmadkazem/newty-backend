namespace Reservation.Domain.Entities.Cities;


public class City : BaseClass<int>
{
    public string FaName { get; set; }
    public string Key  { get; set; }
    public List<string> Alternatives  { get; set; }
}
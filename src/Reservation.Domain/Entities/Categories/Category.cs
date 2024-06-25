namespace Reservation.Domain.Entities.Categories;


public class Category : BaseClass
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImagePath { get; set; }
    public double AveragePoint { get; set; }

    // Sub Categories Rel
    public ICollection<SubCategory> SubCategories { get; set; }

    // Business Point
    public ICollection<Point> Points { get; set; }
}
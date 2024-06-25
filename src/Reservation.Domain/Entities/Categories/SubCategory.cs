namespace Reservation.Domain.Entities.Categories;


public class SubCategory : BaseClass
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImagePath { get; set; }
    public double AveragePoint { get; set; }

    // Parent Category
    public Category Category { get; set; }
    
    // Business Rel
    public ICollection<Business> Businesses { get; set; }

    // Sub Category Point
    public ICollection<Point> Points { get; set; }
}
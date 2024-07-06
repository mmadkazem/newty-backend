namespace Reservation.Domain.Entities.Categories;


public class Category : BaseClass
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string CoverImagePath { get; set; }

    // Sub Categories Rel
    public Category ParentCategory { get; set; }

    // Business Point
    public ICollection<Point> Points { get; set; } = [];
}
namespace Reservation.Application.Categories.Exceptions;


public class CategoryNotFoundException : NewtyNotFoundBaseException
{
    public CategoryNotFoundException()
        : base("دسته بندی یافت نشد") { }
}
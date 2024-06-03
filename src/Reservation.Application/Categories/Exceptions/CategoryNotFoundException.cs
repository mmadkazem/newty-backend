namespace Reservation.Application.Categories.Exceptions;


public class CategoryNotFoundException : ReservationNotFoundBaseException
{
    public CategoryNotFoundException()
        : base("دسته بندی یافت نشد") { }
}
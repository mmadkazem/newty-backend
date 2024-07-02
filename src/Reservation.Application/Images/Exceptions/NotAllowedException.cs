namespace Reservation.Application.Images.Exceptions;


public sealed class NotAllowedRemovedException()
    : ReservationBadRequestBaseException("شما دسترسی حذف کردن این تصویر را ندارید");
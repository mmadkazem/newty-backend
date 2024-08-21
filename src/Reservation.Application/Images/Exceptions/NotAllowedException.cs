namespace Reservation.Application.Images.Exceptions;


public sealed class NotAllowedRemovedException()
    : NewtyBadRequestBaseException("شما دسترسی حذف کردن این تصویر را ندارید");
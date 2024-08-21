namespace Reservation.Application.Common.Exceptions;


public sealed class DoNotAccessToRemoveItemException(string item)
    : NewtyBadRequestBaseException($"شما اجازه پاک کردن این {item} را ندارید");
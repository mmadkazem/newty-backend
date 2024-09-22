namespace Reservation.Application.Finances.BusinessRequestWithdraws.Exceptions;


public sealed class RequestWithdrawIsExistException()
    : NewtyBadRequestBaseException("شما قبلاً درخواست برداشت داده بودید. لطفاً صبور باشید.");
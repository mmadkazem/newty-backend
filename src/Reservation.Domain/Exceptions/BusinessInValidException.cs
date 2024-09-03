namespace Reservation.Domain.Exceptions;


public sealed class BusinessInValidException()
    : NewtyForbiddenBaseException("لطفا اطلاعات را تکمیل کنید یا منتظر تایید کارشناسان ما باشید");
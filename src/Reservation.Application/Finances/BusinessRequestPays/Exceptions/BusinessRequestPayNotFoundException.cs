namespace Reservation.Application.Finances.BusinessRequestPays.Exceptions;


public class BusinessRequestPayNotFoundException()
    : NewtyBadRequestBaseException("همچنین درخواست پرداختی وجود ندارد")
{ }
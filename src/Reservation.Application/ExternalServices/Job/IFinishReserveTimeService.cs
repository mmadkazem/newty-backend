namespace Reservation.Application.ExternalServices.Job;



public interface IFinishReserveTimeJob
{
    void Execute(Guid reserveTimeId, DateTime date);
}
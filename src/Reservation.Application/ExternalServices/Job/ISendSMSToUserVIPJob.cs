namespace Reservation.Application.ExternalServices.Job;



public interface ISendSMSToUserVIPJob
{
    void Send(Guid businessId, DateTime sendDate, string message);
}
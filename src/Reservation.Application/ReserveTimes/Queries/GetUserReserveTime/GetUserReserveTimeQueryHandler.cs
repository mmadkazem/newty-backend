namespace Reservation.Application.ReserveTimes.Queries.GetUserReserveTime;

public class GetUserReserveTimeQueryHandler(IUnitOfWork uow)
    : IRequestHandler<GetUserReserveTimeQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetUserReserveTimeQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.ReserveTimes.GetUserReserveTimes(request.Page, request.Size, request.UserId, request.Finished, cancellationToken);
        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}
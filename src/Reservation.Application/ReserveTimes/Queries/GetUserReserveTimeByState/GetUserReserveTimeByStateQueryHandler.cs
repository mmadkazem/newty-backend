namespace Reservation.Application.ReserveTimes.Queries.GetUserReserveTimeByState;

public class GetUserReserveTimeByStateQueryHandler(IUnitOfWork uow) : IRequestHandler<GetUserReserveTimeByStateQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetUserReserveTimeByStateQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.ReserveTimes.GetUserReserveTimeByState(request.Page, request.Size, request.UserId, request.State, cancellationToken);
        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);

    }
}


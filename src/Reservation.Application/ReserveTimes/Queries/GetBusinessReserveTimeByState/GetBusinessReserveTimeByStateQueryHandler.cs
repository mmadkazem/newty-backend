namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTimeByState;

public class GetBusinessReserveTimeByStateReceiptQueryHandler(IUnitOfWork uow)
    : IRequestHandler<GetBusinessReserveTimeByStateReceiptQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetBusinessReserveTimeByStateReceiptQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.ReserveTimes.GetBusinessReserveTimeByState(request.Page, request.Size, request.State, request.BusinessId, cancellationToken);
        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}
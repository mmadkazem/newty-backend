namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTime;

public sealed class GetBusinessReserveTimeReceiptQueryHandler(IUnitOfWork uow)
    : IRequestHandler<GetBusinessReserveTimeReceiptQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetBusinessReserveTimeReceiptQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.ReserveTimes.GetBusinessReserveTimes(request.Page, request.Size, request.BusinessId, request.Finished, cancellationToken);

        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}
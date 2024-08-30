namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTimeSender;

public sealed class GetBusinessReserveTimeSenderQueryHandler(IUnitOfWork uow)
    : IRequestHandler<GetBusinessReserveTimeSenderQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetBusinessReserveTimeSenderQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.ReserveTimes.GetBusinessReserveTimesSender(request.Page, request.Size, request.Finished, request.BusinessId, cancellationToken);

        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}
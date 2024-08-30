
namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTimeSenderByState;

public sealed class GetBusinessReserveTimeSenderByStateQueryHandler(IUnitOfWork uow)
        : IRequestHandler<GetBusinessReserveTimeSenderByStateQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetBusinessReserveTimeSenderByStateQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.ReserveTimes.GetBusinessReserveTimesSenderByState(request.Page, request.Size, request.State, request.BusinessId, cancellationToken);

        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}
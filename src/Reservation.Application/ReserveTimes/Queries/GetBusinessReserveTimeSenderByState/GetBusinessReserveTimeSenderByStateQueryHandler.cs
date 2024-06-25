
namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTimeSenderByState;

public sealed class GetBusinessReserveTimeSenderByStateQueryHandler(IUnitOfWork uow)
        : IRequestHandler<GetBusinessReserveTimeSenderByStateQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetBusinessReserveTimeSenderByStateQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.ReserveTimes.GetBusinessReserveTimesSenderByState(request.Page, request.State, request.BusinessId, cancellationToken);

        if (!responses.Any())
        {
            throw new ReserveTimeNotFoundException();
        }

        return responses;
    }
}
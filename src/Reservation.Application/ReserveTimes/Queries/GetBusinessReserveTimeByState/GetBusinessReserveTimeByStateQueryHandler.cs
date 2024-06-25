namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTimeByState;

public class GetBusinessReserveTimeByStateReceiptQueryHandler(IUnitOfWork uow) : IRequestHandler<GetBusinessReserveTimeByStateReceiptQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetBusinessReserveTimeByStateReceiptQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.ReserveTimes.GetBusinessReserveTimeByState(request.Page, request.State, request.BusinessId, cancellationToken);
        if (!responses.Any())
        {
            throw new ReserveTimeNotFoundException();
        }

        return responses;
    }
}
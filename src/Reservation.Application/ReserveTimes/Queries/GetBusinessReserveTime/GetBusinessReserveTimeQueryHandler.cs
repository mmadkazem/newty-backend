namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTime;

public sealed class GetBusinessReserveTimeReceiptQueryHandler(IUnitOfWork uow) : IRequestHandler<GetBusinessReserveTimeReceiptQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetBusinessReserveTimeReceiptQueryRequest request, CancellationToken cancellationToken)
    {
        var response = await _uow.ReserveTimes.GetBusinessReserveTimes(request.Page, request.BusinessId, request.Finished, cancellationToken);
        if (!response.Any())
        {
            throw new ReserveTimeNotFoundException();
        }

        return response;
    }
}
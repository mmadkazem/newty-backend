namespace Reservation.Application.ReserveTimes.Queries.GetBusinessReserveTimeSender;

public sealed class GetBusinessReserveTimeSenderQueryHandler(IUnitOfWork uow) : IRequestHandler<GetBusinessReserveTimeSenderQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetBusinessReserveTimeSenderQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.ReserveTimes.GetBusinessReserveTimesSender(request.Page, request.Finished, request.BusinessId, cancellationToken);

        if (!responses.Any())
        {
            throw new ReserveTimeNotFoundException();
        }

        return responses;
    }
}
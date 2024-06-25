namespace Reservation.Application.ReserveTimes.Queries.GetUserReserveTime;

public class GetUserReserveTimeQueryHandler(IUnitOfWork uow) : IRequestHandler<GetUserReserveTimeQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetUserReserveTimeQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.ReserveTimes.GetUserReserveTimes(request.Page, request.UserId, request.Finished, cancellationToken);
        if (!responses.Any())
        {
            throw new ReserveTimeNotFoundException();
        }

        return responses;
    }
}
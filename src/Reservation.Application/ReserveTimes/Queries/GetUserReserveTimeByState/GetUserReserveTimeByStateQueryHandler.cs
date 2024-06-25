namespace Reservation.Application.ReserveTimes.Queries.GetUserReserveTimeByState;

public class GetUserReserveTimeByStateQueryHandler(IUnitOfWork uow) : IRequestHandler<GetUserReserveTimeByStateQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetUserReserveTimeByStateQueryRequest request, CancellationToken cancellationToken)
    {
        var responses = await _uow.ReserveTimes.GetUserReserveTimeByState(request.Page, request.UserId, request.State, cancellationToken);
        if (!responses.Any())
        {
            throw new ReserveTimeNotFoundException();
        }

        return responses;

    }
}


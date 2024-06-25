namespace Reservation.Application.ReserveTimes.Queries.GetFreeTime;

public sealed class GetFreeTimeQueryHandler(IUnitOfWork uow) : IRequestHandler<GetFreeTimeQueryRequest, IEnumerable<IResponse>>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IEnumerable<IResponse>> Handle(GetFreeTimeQueryRequest request, CancellationToken cancellationToken)
    {
        var reserveTimes = await _uow.ReserveTimes.FindAsyncByBusinessId(request.BusinessId, cancellationToken);
        if (reserveTimes.Count == 0)
        {
            throw new ReserveTimeNotFoundException();
        }
        var (start, end) = GetBusinessWorkOfHour();
        List<GetFreeTimeQueryResponse> responses = [];

        GetFreeTimeQueryResponse startResponse = new(start, reserveTimes[0].TotalStartDate);

        GetFreeTimeQueryResponse endResponse = new(reserveTimes[^1].TotalEndDate, end);

        responses.AddRange([startResponse, endResponse]);
        for (int i = 0; i <= reserveTimes.Count; i++)
        {
            if (reserveTimes.Count <= i + 1)
            {
                break;
            }

            var date = new GetFreeTimeQueryResponse(reserveTimes[i].TotalEndDate, reserveTimes[i + 1].TotalStartDate);
            responses.Add(date);
        }

        return responses;
    }

    private static (DateTime start, DateTime end) GetBusinessWorkOfHour()
    {
        var now = DateTime.Now;
        return
        (
            new DateTime(now.Year, now.Month, now.Day, 9, 0, 0),
            new DateTime(now.Year, now.Month, now.Day, 22, 0, 0)
        );
    }
}
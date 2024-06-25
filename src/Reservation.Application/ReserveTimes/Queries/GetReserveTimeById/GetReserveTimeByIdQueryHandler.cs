namespace Reservation.Application.ReserveTimes.Queries.GetReserveTimeById;

public sealed class GetReserveTimeByIdReceiptQueryHandler(IUnitOfWork uow) : IRequestHandler<GetReserveTimeByIdReceiptQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetReserveTimeByIdReceiptQueryRequest request, CancellationToken cancellationToken)
        => await _uow.ReserveTimes.Get(request.Id, cancellationToken)
            ?? throw new ReserveTimeNotFoundException();

}


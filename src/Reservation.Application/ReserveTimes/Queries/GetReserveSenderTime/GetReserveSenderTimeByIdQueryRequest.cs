namespace Reservation.Application.ReserveTimes.Queries.GetReserveSenderTime;


public sealed record GetReserveTimeSenderByIdQueryRequest(Guid Id)
    : IRequest<IResponse>;

public sealed class GetReserveSenderTimeByIdQueryHandler(IUnitOfWork uow)
    : IRequestHandler<GetReserveTimeSenderByIdQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetReserveTimeSenderByIdQueryRequest request, CancellationToken cancellationToken)
        => await _uow.ReserveTimes.GetReserveTimeSender(request.Id, cancellationToken)
            ?? throw new ReserveTimeNotFoundException();
}
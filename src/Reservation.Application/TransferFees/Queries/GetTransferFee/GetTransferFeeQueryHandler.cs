namespace Reservation.Application.TransferFees.Queries.GetTransferFee;

public sealed class GetTransferFeeQueryHandler(IUnitOfWork uow) : IRequestHandler<GetTransferFeeQueryRequest, IResponse>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<IResponse> Handle(GetTransferFeeQueryRequest request, CancellationToken cancellationToken)
        => await _uow.TransferFees.Get(cancellationToken);
}
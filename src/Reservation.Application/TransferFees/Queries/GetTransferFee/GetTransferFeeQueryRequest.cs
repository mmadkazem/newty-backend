namespace Reservation.Application.TransferFees.Queries.GetTransferFee;


public sealed record GetTransferFeeQueryRequest : IRequest<IResponse>;

public sealed record GetTransferFeeQueryResponse(int Percent, DateTime ModifiedOn) : IResponse;

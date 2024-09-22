namespace Reservation.Application.Finances.BusinessRequestWithdraws.Queries.GetBusinessRequestWithdraw;

public sealed class GetBusinessRequestWithdrawQueryHandler(IUnitOfWork uow) : IRequestHandler<GetBusinessRequestWithdrawQueryRequest, Response>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task<Response> Handle(GetBusinessRequestWithdrawQueryRequest request, CancellationToken token)
    {
        var responses = await _uow.BusinessRequestWithdraws.GetAll(request.Page, request.Size, token);
        if (!responses.Any() || responses.Count() < request.Size)
        {
            return new Response(true, responses);
        }

        return new Response(false, responses);
    }
}
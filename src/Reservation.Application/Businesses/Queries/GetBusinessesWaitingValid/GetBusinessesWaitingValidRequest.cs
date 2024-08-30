namespace Reservation.Application.Businesses.Queries.GetBusinessesWaitingValid;


public sealed record GetBusinessesWaitingValidQueryRequest(int Page, int Size) : IRequest<Response>;

public sealed record GetBusinessesWaitingValidItemQueryResponse
(
  Guid Id, string Name, string Description, string CoverImagePath, string ParvaneKasbImagePath,
  string CardNumber, string Address, string PhoneNumber, bool IsCancelReserveTime,
  TimeSpan StartHoursOfWor, TimeSpan EndHoursOfWor, List<DayOfWeek> Holidays, string City
) : IResponse;

public sealed class GetBusinessesWaitingValidQueryHandler(IUnitOfWork uow) : IRequestHandler<GetBusinessesWaitingValidQueryRequest, Response>
{
  private readonly IUnitOfWork _uow = uow;

  public async Task<Response> Handle(GetBusinessesWaitingValidQueryRequest request, CancellationToken cancellationToken)
  {
    var responses = await _uow.Businesses.GetWaitingValidBusiness(request.Page, request.Size, cancellationToken);
    if (!responses.Any() || responses.Count() < request.Size)
    {
      return new Response(true, responses);
    }

    return new Response(false, responses);
  }
}
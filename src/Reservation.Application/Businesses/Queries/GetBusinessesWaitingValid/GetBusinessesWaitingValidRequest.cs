
namespace Reservation.Application.Businesses.Queries.GetBusinessesWaitingValid;


public sealed record GetBusinessesWaitingValidQueryRequest(int Page) : IRequest<IEnumerable<IResponse>>;

public sealed record GetBusinessesWaitingValidQueryResponse
(
  Guid Id, string Name, string Description, string CoverImagePath, string ParvaneKasbImagePath,
  string CardNumber, string Address, string PhoneNumber, bool IsCancelReserveTime,
  TimeSpan StartHoursOfWor, TimeSpan EndHoursOfWor, List<DayOfWeek> Holidays, string City
) : IResponse;

public sealed class GetBusinessesWaitingValidQueryHandler(IUnitOfWork uow) : IRequestHandler<GetBusinessesWaitingValidQueryRequest, IEnumerable<IResponse>>
{
  private readonly IUnitOfWork _uow = uow;

  public async Task<IEnumerable<IResponse>> Handle(GetBusinessesWaitingValidQueryRequest request, CancellationToken cancellationToken)
  {
    var responses = await _uow.Businesses.GetWaitingValidBusiness(request.Page, cancellationToken);
    if (!responses.Any())
    {
      throw new BusinessNotFoundException();
    }
    return responses;
  }
}
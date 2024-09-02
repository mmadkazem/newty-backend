
namespace Reservation.Application.Businesses.Commands.UpdateBusiness;


public sealed record UpdateBusinessCommandRequest
(
    Guid Id, Time StartHoursOfWork, Time EndHoursOfWor,
    IEnumerable<DayOfWeek> Holidays, bool IsClose
) : IRequest
{
    public static UpdateBusinessCommandRequest Create(Guid id, UpdateBusinessDTO model)
        => new(id, model.StartHoursOfWork, model.EndHoursOfWor, model.Holidays, model.IsClose);
}

public readonly record struct UpdateBusinessDTO
(
    Time StartHoursOfWork, Time EndHoursOfWor,
    IEnumerable<DayOfWeek> Holidays, bool IsClose
);

public sealed class UpdateBusinessCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateBusinessCommandRequest>
{
    private readonly IUnitOfWork _uow = uow;

    public async Task Handle(UpdateBusinessCommandRequest request, CancellationToken cancellationToken)
    {
        var business = await _uow.Businesses.FindAsync(request.Id, cancellationToken)
            ?? throw new BusinessNotFoundException();

        business.Holidays.Clear();
        foreach (var holiday in request.Holidays)
        {
            business.Holidays.Add(holiday);
        }
        business.StartHoursOfWor = new(request.StartHoursOfWork.Hour, request.StartHoursOfWork.Minute, 0);
        business.EndHoursOfWor = new(request.EndHoursOfWor.Hour, request.EndHoursOfWor.Minute, 0);
        await _uow.SaveChangeAsync(cancellationToken);
    }
}
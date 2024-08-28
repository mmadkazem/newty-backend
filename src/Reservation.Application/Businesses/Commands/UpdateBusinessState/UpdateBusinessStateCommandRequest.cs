namespace Reservation.Application.Businesses.Commands.UpdateBusinessState;


public sealed record UpdateBusinessStateCommandRequest(Guid Id, bool IsValid) : IRequest;


public sealed class UpdateBusinessStateCommandHandler(IUnitOfWork uow) : IRequestHandler<UpdateBusinessStateCommandRequest>
{
  private readonly IUnitOfWork _uow = uow;

  public async Task Handle(UpdateBusinessStateCommandRequest request, CancellationToken cancellationToken)
  {
    var business = await _uow.Businesses.FindAsync(request.Id, cancellationToken)
      ?? throw new BusinessNotFoundException();

    if (request.IsValid)
    {
      business.State = BusinessState.Valid;
    }
    else
    {
      business.State = BusinessState.InValid;
    }
    await _uow.SaveChangeAsync(cancellationToken);
  }
}
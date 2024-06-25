namespace Reservation.Application.ReserveTimes.Commands.CreateReserveTimeSender;

public sealed class CreateReserveTimeSenderCommandValidator : AbstractValidator<CreateReserveTimeSenderCommandRequest>
{
    private readonly IUnitOfWork _uow;
    public CreateReserveTimeSenderCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;
        RuleFor(r => r.BusinessSenderId)
            .MustAsync(AnyAsyncUser).WithMessage(" کسب کاری با این اطلاعات وجود ندارد");
        RuleFor(r => r.BusinessSenderId)
            .MustAsync(AnyAsyncBusiness).WithMessage("کسب و کاری با این اطلاعات وجود ندارد");
    }

    private async Task<bool> AnyAsyncBusiness(Guid businessId, CancellationToken cancellationToken)
        => await _uow.Businesses.AnyAsync(businessId, cancellationToken);

    private async Task<bool> AnyAsyncUser(Guid userId, CancellationToken cancellationToken)
        => await _uow.Users.AnyAsync(userId,cancellationToken);
}
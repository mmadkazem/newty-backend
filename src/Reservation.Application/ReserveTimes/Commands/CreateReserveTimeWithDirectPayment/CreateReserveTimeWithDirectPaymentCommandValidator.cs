namespace Reservation.Application.ReserveTimes.Commands.CreateReserveTimeWithDirectPayment;

public sealed class CreateReserveTimeWithDirectPaymentCommandValidator : AbstractValidator<CreateReserveTimeWithDirectPaymentCommandRequest>
{
    private readonly IUnitOfWork _uow;
    public CreateReserveTimeWithDirectPaymentCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(r => r.UserId)
            .MustAsync(AnyAsyncUser).WithMessage("کاربری با این اطلاعات وجود ندارد");

        RuleFor(r => r.BusinessId)
            .MustAsync(AnyAsyncBusiness).WithMessage("کسب و کاری با این اطلاعات وجود ندارد");
    }

    private async Task<bool> AnyAsyncBusiness(Guid businessId, CancellationToken cancellationToken)
        => await _uow.Businesses.AnyAsync(businessId, cancellationToken);

    private async Task<bool> AnyAsyncUser(Guid userId, CancellationToken cancellationToken)
        => await _uow.Users.AnyAsync(userId,cancellationToken);
}


namespace Reservation.Application.Account.Commands.UpdateUser;

public sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommandRequest>
{
    private readonly IUnitOfWork _uow;
    public UpdateUserCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(r => r.FullName)
            .NotEmpty().WithMessage("نام و نام خانوادگی نمی تواند خالی باشد")
            .MaximumLength(16).WithMessage("نام شما نمی تواند بیشتر از 50 کاراکتر باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست");

        RuleFor(r => r.City)
            .NotEmpty().WithMessage("شهر نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست")
            .MustAsync(IsNotExistCity).WithMessage("این شهر فعلا پشتیبانی نمی شود");
    }

    private async Task<bool> IsNotExistCity(string city, CancellationToken cancellationToken)
        => await _uow.Cities.AnyAsync(city, cancellationToken);
}
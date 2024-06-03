namespace Reservation.Application.Businesses.Commands.UpdateBusiness;

public class UpdateBusinessCommandValidator : AbstractValidator<UpdateBusinessCommandRequest>
{
    private readonly IUnitOfWork _uow;
    public UpdateBusinessCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;
        RuleFor(b => b.Address)
            .NotEmpty().WithMessage("آدرس نباید خالی باشد لطفا")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمات معتبر نیست لطفا درست وارد کنید");

        RuleFor(b => b.PhoneNumber)
            .NotEmpty().WithMessage("شماره همراه نمی تواند خالی باشد")
            .Must(StringUtils.IsValidPhone).WithMessage("شماره همراه اشتباه است");

        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("نام کسب و کار شما نمی تواند خالی باشد")
            .MaximumLength(50).WithMessage("نام کسب و کار شما نمی تواند بیشتر از 50 کاراکتر باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست");

        RuleFor(r => r.Description)
            .NotEmpty().WithMessage("توضیحات نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمات معتبر نیست");

        RuleFor(r => r.City)
            .NotEmpty().WithMessage("شهر نمی تواند خالی باشد")
            .Must(StringUtils.IsCensoredWords).WithMessage("این کلمه معتبر نیست")
            .MustAsync(IsNotExistCity).WithMessage("این شهر فعلا پشتیبانی نمی شود");
    }
    private async Task<bool> IsNotExistCity(string city, CancellationToken cancellationToken)
        => await  _uow.Cities.AnyAsync(city, cancellationToken);
}

namespace Reservation.Domain.UnitOfWork;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    ICityRepository Cities { get; }
    IBusinessRepository Businesses { get; }
    ICategoryRepository Categories { get; }
    IReserveTimeRepository ReserveTimes { get; }
    IBusinessRequestPayRepository BusinessRequestPays { get; }
    IUserRequestPayRepository UserRequestPays { get; }
    IWalletRepository Wallets { get; }
    IServiceRepository Services { get; }
    IArtistRepository Artists { get; }
    IPostRepository Posts { get; }
    ISmsCreditRepository SmsCredits { get; }
    ISmsTemplateRepository SmsTemplates { get; }
    ISmsPlanRepository SmsPlans { get; }
    ITransferFeeRepository TransferFees { get; }
    ICouponRepository Coupons { get; }
    IBusinessRequestWithdrawRepository BusinessRequestWithdraws { get; }
    Task SaveChangeAsync(CancellationToken cancellationToken = default);
}
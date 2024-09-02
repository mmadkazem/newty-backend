namespace Reservation.Infrastructure.Persistance.UnitOfWorks;

public sealed class UnitOfWork(
    NewtyDbContext context,
    IUserRepository users,
    ICityRepository cities,
    IBusinessRepository businesses,
    ICategoryRepository categories,
    IReserveTimeRepository reserveTimes,
    IBusinessRequestPayRepository businessRequestPays,
    IUserRequestPayRepository userRequestPays,
    IWalletRepository wallets,
    IServiceRepository services,
    IArtistRepository artists,
    IPostRepository posts,
    ISmsCreditRepository smsCredits,
    ISmsTemplateRepository smsTemplates,
    ISmsPlanRepository smsPlans,
    ITransferFeeRepository transferFees,
    ICouponRepository coupons) : IUnitOfWork
{
    private readonly NewtyDbContext _context = context;


    private readonly IUserRepository _users = users;
    public IUserRepository Users => _users;

    private readonly ICityRepository _cities = cities;
    public ICityRepository Cities => _cities;

    private readonly IBusinessRepository _businesses = businesses;
    public IBusinessRepository Businesses => _businesses;

    private readonly ICategoryRepository _categories = categories;
    public ICategoryRepository Categories => _categories;

    private readonly IReserveTimeRepository _reserveTimes = reserveTimes;
    public IReserveTimeRepository ReserveTimes =>
        _reserveTimes;

    private readonly IBusinessRequestPayRepository _businessRequestPays = businessRequestPays;
    public IBusinessRequestPayRepository BusinessRequestPays
        => _businessRequestPays;

    private readonly IUserRequestPayRepository _userRequestPays = userRequestPays;
    public IUserRequestPayRepository UserRequestPays
        => _userRequestPays;

    private readonly IWalletRepository _wallets = wallets;
    public IWalletRepository Wallets
        => _wallets;

    private readonly IServiceRepository _services = services;
    public IServiceRepository Services
        => _services;

    private readonly IArtistRepository _artists = artists;
    public IArtistRepository Artists
        => _artists;

    private readonly IPostRepository _posts = posts;
    public IPostRepository Posts
        => _posts;

    private readonly ISmsCreditRepository _smsCredits = smsCredits;
    public ISmsCreditRepository SmsCredits
        => _smsCredits;

    private readonly ISmsTemplateRepository _smsTemplates = smsTemplates;
    public ISmsTemplateRepository SmsTemplates
        => _smsTemplates;

    private readonly ISmsPlanRepository _smsPlans = smsPlans;
    public ISmsPlanRepository SmsPlans
        => _smsPlans;

    private readonly ITransferFeeRepository _transferFees = transferFees;
    public ITransferFeeRepository TransferFees
        => _transferFees;

    private readonly ICouponRepository _coupons = coupons;
    public ICouponRepository Coupons
        => _coupons;

    public async Task SaveChangeAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);


}
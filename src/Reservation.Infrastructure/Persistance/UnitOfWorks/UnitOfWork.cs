namespace Reservation.Infrastructure.Persistance.UnitOfWorks;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ReservationDbContext _context;
    public UnitOfWork(
        ReservationDbContext context,
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
        ISmsTemplateRepository smsTemplates)
    {
        _users = users;
        _context = context;
        _cities = cities;
        _businesses = businesses;
        _categories = categories;
        _reserveTimes = reserveTimes;
        _businessRequestPays = businessRequestPays;
        _userRequestPays = userRequestPays;
        _wallets = wallets;
        _services = services;
        _artists = artists;
        _posts = posts;
        _smsCredits = smsCredits;
        _smsTemplates = smsTemplates;
    }

    private readonly IUserRepository _users;
    public IUserRepository Users => _users;

    private readonly ICityRepository _cities;
    public ICityRepository Cities => _cities;

    private readonly IBusinessRepository _businesses;
    public IBusinessRepository Businesses => _businesses;

    private readonly ICategoryRepository _categories;
    public ICategoryRepository Categories => _categories;

    private readonly IReserveTimeRepository _reserveTimes;
    public IReserveTimeRepository ReserveTimes =>
        _reserveTimes;

    private readonly IBusinessRequestPayRepository _businessRequestPays;
    public IBusinessRequestPayRepository BusinessRequestPays
        => _businessRequestPays;

    private readonly IUserRequestPayRepository _userRequestPays;
    public IUserRequestPayRepository UserRequestPays
        => _userRequestPays;

    private readonly IWalletRepository _wallets;
    public IWalletRepository Wallets
        => _wallets;

    private readonly IServiceRepository _services;
    public IServiceRepository Services
        => _services;

    private readonly IArtistRepository _artists;
    public IArtistRepository Artists
        => _artists;

    private readonly IPostRepository _posts;
    public IPostRepository Posts
        => _posts;

    private readonly ISmsCreditRepository _smsCredits;
    public ISmsCreditRepository SmsCredits
        => _smsCredits;

    private readonly ISmsTemplateRepository _smsTemplates;
    public ISmsTemplateRepository SmsTemplates
        => _smsTemplates;

    public async Task SaveChangeAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);


}
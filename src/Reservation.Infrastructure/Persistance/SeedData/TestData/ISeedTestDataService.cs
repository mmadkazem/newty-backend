namespace Reservation.Infrastructure.Persistance.SeedData.TestData;


public interface ISeedTestDataService
{
    void SeedData();
}


public class SeedTestDataService(IServiceScopeFactory serviceScopeFactory) : ISeedTestDataService
{
    private readonly IServiceScopeFactory _serviceScope = serviceScopeFactory;

    public void SeedData()
    {

        using var serviceScope = _serviceScope.CreateScope();
        using var _context = serviceScope.ServiceProvider.GetService<ReservationDbContext>();
        if (!_context.Businesses.Any())
        {
            var city = _context.Cities.FirstOrDefault(c => c.FaName == "تهران");
            var categories = _context.Categories.Where(u => u.ParentCategory.Title == "سالن های زیبایی").ToList();
            Business business = new()
            {
                Id = Guid.NewGuid(),
                Address = "For Test",
                CoverImagePath = "for Test",
                Name = "سالن بهرامی",
                Description = "For Test",
                PhoneNumber = "09301594136",
                StartHoursOfWor = new TimeSpan(9, 0, 0),
                EndHoursOfWor = new TimeSpan(22, 0, 0),
                Holidays = [DayOfWeek.Friday],
                IsValid = true,
                ParvaneKasbImagePath = "For Test",
                Wallet = new(),
                IsCancelReserveTime = false,
                SmsCredit = new() { SmsCount = 100},
                City = city,
                Categories = categories
            };
            BusinessService service = new()
            {
                Id = Guid.NewGuid(),
                Name = "اصلاح مو",
                Active = true,
                Price = 50_000,
                Time = new TimeOnly(0, 40),
                BusinessId = business.Id,
            };

            BusinessService service2 = new()
            {
                Id = Guid.NewGuid(),
                Name = "رنگ مو",
                Active = true,
                Price = 1_000_000,
                Time = new TimeOnly(1, 40),
                BusinessId = business.Id,
            };

            Artist artist = new()
            {
                Id = Guid.NewGuid(),
                Active = true,
                Name = "محمد",
                Description = "For Test",
                BusinessId = business.Id,
                CoverImagePath = "For Test",
                Services = [service]
            };

            Artist artist2 = new()
            {
                Id = Guid.NewGuid(),
                Active = true,
                Name = "رضا",
                Description = "For Test",
                BusinessId = business.Id,
                CoverImagePath = "For Test",
                Services = [service2]
            };

            _context.Businesses.Add(business);
            _context.Artists.AddRange([artist, artist2]);
            _context.Services.AddRange([service, service2]);
            _context.SaveChanges();
        }
    }
}
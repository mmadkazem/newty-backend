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
            var categoriesSolon = _context.Categories.Where(u => u.ParentCategory.Title == "سالن های زیبایی").ToList();
            var categoriesTattoo = _context.Categories.Where(u => u.ParentCategory.Title == "تتو").ToList();
            var categoriesClinic = _context.Categories.Where(u => u.ParentCategory.Title == "کلینیک زیبایی").ToList();
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
                SmsCredit = new() { SmsCount = 100 },
                City = city,
                Categories = categoriesSolon
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

            Business business2 = new()
            {
                Id = Guid.NewGuid(),
                Address = "For Test",
                CoverImagePath = "for Test",
                Name = "سالن رز",
                Description = "For Test",
                PhoneNumber = "09301594137",
                StartHoursOfWor = new TimeSpan(9, 0, 0),
                EndHoursOfWor = new TimeSpan(22, 0, 0),
                Holidays = [DayOfWeek.Friday],
                IsValid = true,
                ParvaneKasbImagePath = "For Test",
                Wallet = new(),
                IsCancelReserveTime = false,
                SmsCredit = new() { SmsCount = 50 },
                City = city,
                Categories = categoriesTattoo
            };
            BusinessService service3 = new()
            {
                Id = Guid.NewGuid(),
                Name = "تتوی چشم",
                Active = true,
                Price = 3_000_000,
                Time = new TimeOnly(0, 40),
                BusinessId = business.Id,
            };

            BusinessService service4 = new()
            {
                Id = Guid.NewGuid(),
                Name = "تتوی دست",
                Active = true,
                Price = 4_000_000,
                Time = new TimeOnly(1, 40),
                BusinessId = business.Id,
            };

            Artist artist3 = new()
            {
                Id = Guid.NewGuid(),
                Active = true,
                Name = "زهرا",
                Description = "For Test",
                BusinessId = business.Id,
                CoverImagePath = "For Test",
                Services = [service3]
            };

            Artist artist4 = new()
            {
                Id = Guid.NewGuid(),
                Active = true,
                Name = "مهسان",
                Description = "For Test",
                BusinessId = business.Id,
                CoverImagePath = "For Test",
                Services = [service4]
            };

            Business business3 = new()
            {
                Id = Guid.NewGuid(),
                Address = "For Test",
                CoverImagePath = "for Test",
                Name = "تهران کلینیک",
                Description = "For Test",
                PhoneNumber = "09301594138",
                StartHoursOfWor = new TimeSpan(9, 0, 0),
                EndHoursOfWor = new TimeSpan(22, 0, 0),
                Holidays = [DayOfWeek.Friday],
                IsValid = true,
                ParvaneKasbImagePath = "For Test",
                Wallet = new(),
                IsCancelReserveTime = false,
                SmsCredit = new() { SmsCount = 100 },
                City = city,
                Categories = categoriesClinic
            };
            BusinessService service5 = new()
            {
                Id = Guid.NewGuid(),
                Name = "عمل بینی",
                Active = true,
                Price = 30_000_000,
                Time = new TimeOnly(0, 40),
                BusinessId = business.Id,
            };

            BusinessService service6 = new()
            {
                Id = Guid.NewGuid(),
                Name = "زاویه فک",
                Active = true,
                Price = 10_000_000,
                Time = new TimeOnly(1, 40),
                BusinessId = business.Id,
            };

            Artist artist5 = new()
            {
                Id = Guid.NewGuid(),
                Active = true,
                Name = "دکتر رمضان پورمختار",
                Description = "For Test",
                BusinessId = business.Id,
                CoverImagePath = "For Test",
                Services = [service5]
            };

            Artist artist6 = new()
            {
                Id = Guid.NewGuid(),
                Active = true,
                Name = "دکتر هانیه اخباری",
                Description = "For Test",
                BusinessId = business.Id,
                CoverImagePath = "For Test",
                Services = [service6]
            };
            _context.Businesses.AddRange([business, business2, business3]);
            _context.Artists.AddRange([artist, artist2, artist3, artist4, artist5, artist6]);
            _context.Services.AddRange([service, service2, service3, service4, service5, service6]);
            _context.SaveChanges();
        }
    }
}
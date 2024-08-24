namespace Reservation.Infrastructure.Persistance.SeedData.Categories;


public interface ICategorySeedData
{
    void SeedData();
}

public sealed class CategorySeedData(IServiceScopeFactory serviceScope) : ICategorySeedData
{
    private readonly IServiceScopeFactory _serviceScope = serviceScope;

    public void SeedData()
    {
        using var serviceScope = _serviceScope.CreateScope();
        using var _context = serviceScope.ServiceProvider.GetService<NewtyDbContext>();
        var _readService = serviceScope.ServiceProvider.GetService<IReadCategoryInJsonService>();

        if (!_context.Categories.Any())
        {
            #region Seed Parent Category
            var parentCategories = _readService.GetParentCategory();
            _context.AddRange(parentCategories);
            _context.SaveChanges();
            #endregion

            #region  Seed beauty Salon Childs Categories
            var beautySalonCategory = parentCategories.FirstOrDefault(c => c.Title == "سالن های زیبایی");
            var beautySalonChildsCategories = _readService.GetBeautySalonChildsCategory();
            foreach (var beautySalonChildsCategory in beautySalonChildsCategories)
            {
                beautySalonChildsCategory.ParentCategory = beautySalonCategory;
            }
            _context.AddRange(beautySalonChildsCategories);
            #endregion

            #region Seed Clinic Salon Childs Categories
            var clinicSalonCategory = parentCategories.FirstOrDefault(c => c.Title == "کلینیک زیبایی");
            var clinicSalonChildsCategories = _readService.GetClinicSalonChildsCategory();
            foreach (var clinicSalonChildsCategory in clinicSalonChildsCategories)
            {
                clinicSalonChildsCategory.ParentCategory = clinicSalonCategory;
            }
            _context.AddRange(clinicSalonChildsCategories);
            #endregion

            #region  Seed tattoo Childs Categories
            var tattooCategory = parentCategories.FirstOrDefault(c => c.Title == "تتو");
            var tattooChildsCategories = _readService.GetTattooChildsCategory();
            foreach (var tattooChildsCategory in tattooChildsCategories)
            {
                tattooChildsCategory.ParentCategory = tattooCategory;
            }
            _context.AddRange(tattooChildsCategories);
            #endregion

            _context.SaveChanges();
        }
    }
}

public interface IReadCategoryInJsonService
{
    List<Category> GetParentCategory();
    List<Category> GetBeautySalonChildsCategory();
    List<Category> GetClinicSalonChildsCategory();
    List<Category> GetTattooChildsCategory();
}

public sealed class ReadCategoryInJsonService : IReadCategoryInJsonService
{
    public List<Category> GetParentCategory()
    {
        string categorySeedPath = Path.Combine
        (
            BaseDirectoryPath.InfrastructureDirectoryPath,
            @$"{BaseDirectoryPath.CategoryPath}parents-category.json"
        );

        // Read File
        using StreamReader r = new(categorySeedPath);
        string json = r.ReadToEnd();

        // Deserialize
        return JsonSerializer.Deserialize<List<Category>>(json);
    }
    public List<Category> GetTattooChildsCategory()
    {
        string categorySeedPath = Path.Combine
        (
            BaseDirectoryPath.InfrastructureDirectoryPath,
            @$"{BaseDirectoryPath.CategoryPath}tattoo-childs.json"
        );

        // Read File
        using StreamReader r = new(categorySeedPath);
        string json = r.ReadToEnd();

        // Deserialize
        return JsonSerializer.Deserialize<List<Category>>(json);
    }
    public List<Category> GetBeautySalonChildsCategory()
    {
        string categorySeedPath = Path.Combine
        (
            BaseDirectoryPath.InfrastructureDirectoryPath,
            @$"{BaseDirectoryPath.CategoryPath}beauty-salon-childs.json"
        );

        // Read File
        using StreamReader r = new(categorySeedPath);
        string json = r.ReadToEnd();

        // Deserialize
        return JsonSerializer.Deserialize<List<Category>>(json);
    }
    public List<Category> GetClinicSalonChildsCategory()
    {
        string categorySeedPath = Path.Combine
        (
            BaseDirectoryPath.InfrastructureDirectoryPath,
            @$"{BaseDirectoryPath.CategoryPath}clinic-salon-childs.json"
        );

        // Read File
        using StreamReader r = new(categorySeedPath);
        string json = r.ReadToEnd();

        // Deserialize
        return JsonSerializer.Deserialize<List<Category>>(json);
    }
}

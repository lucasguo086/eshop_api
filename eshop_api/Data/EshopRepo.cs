using eshop_api.Model;

namespace eshop_api.Data;

public class EshopRepo:IEshopRepo
{
    private readonly EshopDbContext _dbContext;

    public EshopRepo(EshopDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public bool ValidLogin(string userName, string password)
    {
        if (userName == "admin" && password == "admin123")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerable<Product> GetAllProducts()
    {
        IEnumerable<Product> products = _dbContext.Products.ToList();
        return products;
    }
}
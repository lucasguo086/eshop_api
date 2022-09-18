namespace eshop_api.Data;
using eshop_api.Model;
public interface IEshopRepo
{
    bool ValidLogin(string userName, string password);
    public IEnumerable<Product> GetAllProducts();
}
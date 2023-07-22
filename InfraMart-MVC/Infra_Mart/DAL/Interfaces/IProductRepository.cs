using Infra_Mart.Models;

namespace Infra_Mart.DAL.Interfaces
{
    public interface IProductRepository
    {
        bool AddProduct(Product product);
        List<Product> getAllProducts();
    }
}

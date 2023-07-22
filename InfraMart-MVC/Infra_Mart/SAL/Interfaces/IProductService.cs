using Infra_Mart.Models;

namespace Infra_Mart.SAL.Interfaces
{
    public interface IProductService
    {
        bool AddProduct(Product product);
        List<Product> getProducts();
    }
}

using Infra_Mart.DAL.Interfaces;
using Infra_Mart.Models;

namespace Infra_Mart.SAL.Services
{
    public class ProductServiceImpl:Interfaces.IProductService
    {
        public readonly IProductRepository _prodrepository;

        public ProductServiceImpl(IProductRepository prodrepository)
        {
            _prodrepository = prodrepository;
        }

        public bool AddProduct(Product product)
        {
            Boolean status = _prodrepository.AddProduct(product);
            return status;
        }

        public List<Product> getProducts()
        {
            List<Product> prodlist = _prodrepository.getAllProducts();
            return prodlist;
        }
    }
}

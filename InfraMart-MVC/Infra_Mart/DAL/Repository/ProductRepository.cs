using Infra_Mart.DataContext;
using Infra_Mart.Models;
using System.Linq;

namespace Infra_Mart.DAL.Repository
{
    public class ProductRepository:Interfaces.IProductRepository
    {

        public readonly CollectionContex _ctx;
        public ProductRepository(CollectionContex ctx)
        {
            _ctx = ctx;
        }

        public bool AddProduct(Product product)
        {
            _ctx.Product.Add(product);
            _ctx.SaveChanges();
            return true;
        }

        public List<Product> getAllProducts()
        {

            //CollectionContex ctx = new CollectionContex();
            
            
            var products = from product in _ctx.Product select product;
            return products.ToList<Product>();
        }


    }
}

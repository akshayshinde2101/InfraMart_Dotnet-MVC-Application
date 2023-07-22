using Org.BouncyCastle.Asn1.Crmf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra_Mart.Models
{
    [Table ("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int ProductUnit { get; set; }
        public  string  ProductImage { get; set; }
       public Category ProductCategory { get; set; }
        public int ProductCategoryCategoryId { get; set; }
        
        public Product()
        {
     
        }

        public override string ToString()
        {
            return ("ProductID:" + ProductId + "ProductName:" + ProductName);
        }
    }
}

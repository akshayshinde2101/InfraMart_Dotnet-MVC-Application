using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra_Mart.Models
{
    public class Category
    {
        [Key]
      
        public int CategoryId { get; set; }

        [Column("CategoryName", TypeName = "varchar(300)")]
        public string CategoryName { get; set; }

        public List<Product> ProductList { get; set; }
        public Category( string categoryName)
        {
          //  CategoryId = categoryId;
            CategoryName = categoryName;
           // ProductList = productList;
        }
    }
}

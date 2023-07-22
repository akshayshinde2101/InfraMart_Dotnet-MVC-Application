
namespace Infra_Mart.Models
{
    public class FileUpload
    {
       
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int ProductUnit { get; set; }

        public int  ProductCategoryId { get; set; }
        public IFormFile Image { get; set; }

    }
}

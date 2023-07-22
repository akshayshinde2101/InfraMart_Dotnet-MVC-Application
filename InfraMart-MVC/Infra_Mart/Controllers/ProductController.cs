using Infra_Mart.DataContext;
using Infra_Mart.Models;
using Infra_Mart.SAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Infra_Mart.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _prodservice;
        private readonly CollectionContex _ctx;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICategoryService _categoryService123;

        public ProductController(IProductService prodservice, CollectionContex ctx, IWebHostEnvironment webHostEnvironment, ICategoryService categoryService123)
        {
            _prodservice = prodservice;
            _ctx = ctx; 
            _webHostEnvironment = webHostEnvironment;
            _categoryService123 = categoryService123;
        }


        // GET: Product
        public ActionResult ViewAll()
        {
            var products = _ctx.Product.ToList();
            ViewData["products"] = products;  
            return View();
        }

        // GET: Product/Details/5
        /*public ActionResult Details(int id)
        {
            return View();
        }*/
        public IActionResult AddProduct()
        {

            var categories = _categoryService123.getAllCategories();
            ViewData["Categories"] = categories;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(FileUpload imagefile )
        {
            Console.WriteLine(imagefile.ProductCategoryId);
            // Product product = JsonConvert.DeserializeObject<Product>(fileobj.Product);
            string file = uploadFile(imagefile);
            var product = new Product()
            {
                ProductName = imagefile.ProductName,
                ProductDescription = imagefile.ProductDescription,
                ProductPrice = imagefile.ProductPrice,
                ProductUnit = imagefile.ProductUnit,
                ProductCategoryCategoryId = imagefile.ProductCategoryId,
                ProductImage = file
            };
            _ctx.Product.Add(product);
            _ctx.SaveChanges();
            return RedirectToAction("ViewAllAdmin","Admin");
        }

        private string uploadFile(FileUpload imagefile)
        {
            string filenew = null;
            if(imagefile!=null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                filenew = Guid.NewGuid().ToString() + "-" + imagefile.Image.FileName;
                string filepath = Path.Combine(uploadDir, filenew);
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {
                    imagefile.Image.CopyTo(fileStream);
                }
            }
            return filenew;
        }
    }
}

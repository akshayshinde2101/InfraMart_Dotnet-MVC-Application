using Infra_Mart.Models;
using Infra_Mart.SAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Infra_Mart.Controllers
{
    public class CategoryController : Controller
    {

        public readonly ICategoryService _categoryservice;
        public CategoryController (ICategoryService categoryservice)
        {
            _categoryservice = categoryservice;
        }
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(string categoryName)
        {
            Boolean status = _categoryservice.addNewCategory(categoryName);
            if(status)
            {
                return RedirectToAction("ShowAllCategory", "Category");
            }

            return View();
        }

        public IActionResult ShowAllCategory()
        {
            List<Category> categorylist = _categoryservice.getAllCategories();
            ViewData["catlist"] = categorylist;
            return View();
        }

        public IActionResult DeleteCategory(int id)
        {
            //int id1 = Int32.Parse(id);
            Boolean status = _categoryservice.deleteCategoriy(id);
            if (status) { 
                return RedirectToAction("ShowAllCategory", "Category");
            }
            return View();
        }
          
    }
}

using Infra_Mart.DAL.Interfaces;
using Infra_Mart.Models;

namespace Infra_Mart.SAL.Services
{
    public class CategoryServiceImpl : Interfaces.ICategoryService
    {

        public readonly ICategoryRepository _categoryrepository;
        public CategoryServiceImpl(ICategoryRepository categoryrepository)
        {
            _categoryrepository = categoryrepository;
        }

        public bool addNewCategory(string categoryName)
        {
            Boolean status = _categoryrepository.addCategory(categoryName);
            return status;
        }

        public bool deleteCategoriy(int id)
        {
            Boolean status = _categoryrepository.deleteCategory(id);
            return status;
        }

        public List<Category> getAllCategories()
        {
            List<Category> catlist = _categoryrepository.getCategories();
            return catlist;
        }
    }
}

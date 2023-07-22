using Infra_Mart.Models;

namespace Infra_Mart.SAL.Interfaces
{
    public interface ICategoryService
    {
        bool addNewCategory(string categoryName);
        bool deleteCategoriy(int id);
        List<Category> getAllCategories();
    }
}

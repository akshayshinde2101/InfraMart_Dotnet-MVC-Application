using Infra_Mart.Models;

namespace Infra_Mart.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        bool addCategory(string categoryName);
        bool deleteCategory(int id);
        List<Category> getCategories();
    }
}

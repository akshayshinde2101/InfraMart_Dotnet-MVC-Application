using Infra_Mart.DataContext;
using Infra_Mart.Models;
using MySqlX.XDevAPI.CRUD;
using System.Linq;

namespace Infra_Mart.DAL.Repository
{
    public class CategoryRepository : Interfaces.ICategoryRepository
    {

        public readonly CollectionContex _ctx;
        public CategoryRepository(CollectionContex ctx)
        {
            _ctx = ctx;
        }

        public bool addCategory(string categoryName)
        {
            Category cat = new Category(categoryName);
            _ctx.Add(cat);
            _ctx.SaveChanges();
            return true;
        }

        public bool deleteCategory(int id)
        {
            var category = _ctx.Category.Single(cat => cat.CategoryId == id);
            _ctx.Category.Remove(category);
            _ctx.SaveChanges();
            return true;
        }

        public List<Category> getCategories()
        {
            var Categories = from category in _ctx.Category select category;
            return Categories.ToList<Category>();
        }
    }
}

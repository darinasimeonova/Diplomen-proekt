using MusicShopWebApp.Entities;
using System.Collections.Generic;

namespace MusicShopWebApp.Abstraction
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryById(int categoryId);
        List<Product> GetProductsByCategory(int categoryId);
    }
}

using MusicShopWebApp.Entities;
using System.Collections.Generic;

namespace MusicShopWebApp.Abstraction
{
    public interface IProductService
    {
        bool Create(string name, int categoryId, int brandId, string description, string photo, decimal price, int quantity, decimal discount);
        bool Update(int productId, string name, int categoryId, int brandId, string description, string photo, decimal price, int quantity, decimal discount);
        List<Product> GetProducts();
        Product GetProductById(int productId);
        bool RemoveById(int productId);
        List<Product> GetProducts(string searchStringCategoryName, string searchStringDesignerName);
    }
}

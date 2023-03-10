using MusicShopWebApp.Entities;
using System.Collections.Generic;
using System.Data;

namespace MusicShopWebApp.Abstraction
{
    public interface IBrandService
    {
        List<Brand> GetBrands();
        Brand GetBrandById(int brandId);
        List<Product> GetProductsByBrand(int brandId);
    }
}

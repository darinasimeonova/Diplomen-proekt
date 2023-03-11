using MusicShopWebApp.Abstraction;
using MusicShopWebApp.Data;
using MusicShopWebApp.Entities;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace MusicShopWebApp.Services
{
    public class BrandService : IBrandService
    {
        private readonly ApplicationDbContext _context;
        public BrandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Brand GetBrandById(int brandId)
        {
            //throw new System.NotImplementedException();
            return _context.Brands.Find(brandId);
        }

        public List<Brand> GetBrands()
        {
            // throw new System.NotImplementedException();
            List<Brand> brands = _context.Brands.ToList();
            return brands;
        }


        public List<Brand> GetDesigners()
        {
            List<Brand> designers = _context.Brands.ToList();
            return designers;
        }

        public List<Product> GetProductsByBrand(int brandId)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetProductsByDesigner(int designerId)
        {
            return _context.Products.Where(x => x.BrandId == designerId).ToList();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MusicShopWebApp.Abstraction;
using MusicShopWebApp.Models.Brand;
using MusicShopWebApp.Models.Category;
using MusicShopWebApp.Models.Product;
using System;
using System.Linq;

namespace MusicShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;

        public ProductController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
            this._brandService = brandService;
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var product = new ProductCreateVM();
            product.Brands = _brandService.GetBrands().Select(x => new BrandPairVM()
            {
                Id = x.Id,
                Name = x.BrandName
            }).ToList();
            product.Categories = _categoryService.GetCategories().Select(x => new CategoryPairVM()
            {
                Id = x.Id,
                Name = x.CategoryName
            }).ToList();
            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ProductCreateVM product)
        {
            if (ModelState.IsValid)
            {
                var createdId = _productService.Create(product.ProductName, product.CategoryId,
                                                       product.BrandId, product.Description,
                                                       product.Picture, product.Price,
                                                       product.Quantity, product.Discount);
                if (createdId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
    }
}

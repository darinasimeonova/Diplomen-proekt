using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicShopWebApp.Abstraction;
using MusicShopWebApp.Entities;
using MusicShopWebApp.Models.Brand;
using MusicShopWebApp.Models.Category;
using MusicShopWebApp.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicShopWebApp.Controllers
{
    [Authorize(Roles = "Administrator")] 
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

        // GET: ProductController
        [AllowAnonymous]
        public ActionResult Index(string searchStringCategoryName, string searchStringDesignerName)
        {
            List<ProductIndexVM> products = _productService.GetProducts(searchStringCategoryName, searchStringDesignerName)
               .Select(product => new ProductIndexVM
               {
                   Id = product.Id,
                   Name = product.ProductName,
                   CategoryId = product.CategoryId,
                   CategoryName = product.Category.CategoryName,
                   BrandId = product.BrandId,
                   BrandName = product.Brand.BrandName,
                   Description = product.Description,
                   Picture = product.Picture,
                   Price = product.Price,
                   Quantity = product.Quantity,
                   Discount = product.Discount

               }).ToList();
            return View(products);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            ProductEditVM updatedProduct = new ProductEditVM()
            {
                Id = product.Id,
                Name = product.ProductName,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                Description = product.Description,
                Photo = product.Picture,
                Price = product.Price,
                Quantity = product.Quantity,
                Discount = product.Discount
            };
            updatedProduct.Brands = _brandService.GetBrands().Select(b => new BrandPairVM()
            {
                Id = b.Id,
                Name = b.BrandName
            }).ToList();
            updatedProduct.Categories = _categoryService.GetCategories().Select(c => new CategoryPairVM()
            {
                Id = c.Id,
                Name = c.CategoryName
            }).ToList();
            return View(updatedProduct);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEditVM product)
        {
            if (ModelState.IsValid)
            {
                var updated = _productService.Update(id, product.Name,
                    product.CategoryId, product.BrandId, product.Description, product.Photo,
                    product.Price, product.Quantity, product.Discount);
                if (updated)
                {
                    return this.RedirectToAction("Index");
                }
            }
            return View(product);
        }

        // GET: ProductController/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Product item = _productService.GetProductById(id);
            if (item == null)
            {
                return NotFound();
            }
            ProductDetailsVM product = new ProductDetailsVM()
            {
                Id = item.Id,
                Name = item.ProductName,
                CategoryId = item.CategoryId,
                CategoryName = item.Category.CategoryName,
                BrandId = item.BrandId,
                BrandName = item.Brand.BrandName,
                Description = item.Description,
                Picture = item.Picture ,
                Price = item.Price,
                Quantity = item.Quantity,
                Discount = item.Discount
            };
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            Product item = _productService.GetProductById(id);
            if (item == null)
            {
                return NotFound();
            }
            ProductDeleteVM product = new ProductDeleteVM()
            {
                Id = item.Id,
                Name = item.ProductName,
                CategoryId = item.CategoryId,
                BrandId = item.BrandId,
                Description = item.Description,
                Picture = item.Picture,
                Price = item.Price,
                Quantity = item.Quantity,
                Discount = item.Discount
            };
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _productService.RemoveById(id);
            if (deleted)
            {
                return this.RedirectToAction("Success");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}

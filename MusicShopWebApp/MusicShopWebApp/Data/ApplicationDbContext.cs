using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicShopWebApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MusicShopWebApp.Models.Product;

namespace MusicShopWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MusicShopWebApp.Models.Product.ProductCreateVM> ProductCreateVM { get; set; }
        public DbSet<MusicShopWebApp.Models.Product.ProductIndexVM> ProductIndexVM { get; set; }
        public DbSet<MusicShopWebApp.Models.Product.ProductEditVM> ProductEditVM { get; set; }
        public DbSet<MusicShopWebApp.Models.Product.ProductDetailsVM> ProductDetailsVM { get; set; }
        public DbSet<MusicShopWebApp.Models.Product.ProductDeleteVM> ProductDeleteVM { get; set; }

    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MusicShopWebApp.Data;
using MusicShopWebApp.Entities;
using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebApp.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

            var dataCategory = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedCategories(dataCategory);
            var dataDesigner = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedDesigners(dataDesigner);

            return app;
        }
        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Administrator", "Client" };
            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "admin";
                user.LastName = "admin";
                user.PhoneNumber = "0898989898";
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                var result = await userManager.CreateAsync(user, "admin123");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
        private static void SeedCategories(ApplicationDbContext dataCategory)
        {
            if (dataCategory.Categories.Any())
            {
                return;
            }
            dataCategory.Categories.AddRange(new[]
            {
                new Category {CategoryName="Guitars"},
                new Category {CategoryName="Percussion instruments"},
                new Category {CategoryName="Keyboard instruments"},
                new Category {CategoryName="Orchestral instruments"},
                new Category {CategoryName="Accessories"}
            });
            dataCategory.SaveChanges();
        }
        private static void SeedDesigners(ApplicationDbContext dataDesigner)
        {
            if (dataDesigner.Brands.Any())
            {
                return;
            }
            dataDesigner.Brands.AddRange(new[]
            {
                new Brand {BrandName="YAMAHA"},
                new Brand {BrandName="SAMSON"},
                new Brand {BrandName="IBANEZ"},
                new Brand {BrandName="STAGG"}
            });
            dataDesigner.SaveChanges();
        }

    }
}

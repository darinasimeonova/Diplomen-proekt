using MusicShopWebApp.Models.Brand;
using MusicShopWebApp.Models.Category;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MusicShopWebApp.Models.Product
{
    public class ProductCreateVM
    {
        public ProductCreateVM()
        {
            Brands = new List<BrandPairVM>();
            Categories = new List<CategoryPairVM>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Category")]

        public int CategoryId { get; set; }
        public virtual List<CategoryPairVM> Categories { get; set; }


        [Required]
        [Display(Name = "Designer")]

        public int BrandId { get; set; }
        public virtual List<BrandPairVM> Brands { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Picture")]

        public string Picture { get; set; }

        [Required]
        [Range(1, 5000, ErrorMessage = "Price must be positive in range 1-5000.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]

        public decimal Price { get; set; }

        [Required]
        [Range(0, 50, ErrorMessage = "Quantity must be positive in range 0-50.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
    }
}

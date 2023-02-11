using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicShop_WebApp.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string ProductName { get; set; }
        [Required]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        [Required]
        public virtual Category Category { get; set; }
        [Required]
        public string Picture { get; set; }

        [Required]
        [Range(0, 5000)]
        public int Quantity { get; set; }
        [Required]
        [Range(1,5000)]
        public decimal Price { get; set; }
        [Range(1, 100)]
        public decimal Discount { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}

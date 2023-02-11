using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicShop_WebApp.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]    
        public string BrandName { get; set; }

        public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
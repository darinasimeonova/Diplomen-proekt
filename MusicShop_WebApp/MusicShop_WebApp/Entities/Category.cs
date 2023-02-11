using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicShop_WebApp.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string CategoryName { get; set; }

        public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}

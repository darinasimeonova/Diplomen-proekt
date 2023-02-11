using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace MusicShopWebApp.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Range(0, 10000)]
        public decimal Price { get; set; }
        [Range(0, 100)]
        public decimal Discount { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return Quantity * Price - Quantity * Price * Discount / 100;
            }
        }
    }
}

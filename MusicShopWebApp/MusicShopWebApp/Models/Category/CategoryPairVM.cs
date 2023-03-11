using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MusicShopWebApp.Models.Category
{
    public class CategoryPairVM
    {
        public int Id { get; set; }
        [Display(Name = "Category")]
        public string Name { get; set; }
    }
}

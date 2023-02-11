using Microsoft.AspNetCore.Identity;

namespace MusicShop_WebApp.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string Address { get; set; }
    }
}

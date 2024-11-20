using Microsoft.AspNetCore.Identity;

namespace BookManagement.Models
{
    public class ApplicationUser  : IdentityUser
    {
        public string Adderss { get; set; }
    }
}

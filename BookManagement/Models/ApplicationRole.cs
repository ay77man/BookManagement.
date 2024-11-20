using Microsoft.AspNetCore.Identity;

namespace BookManagement.Models
{
    public class ApplicationRole:IdentityRole
    {
        public string Description { get; set; }
    }
}

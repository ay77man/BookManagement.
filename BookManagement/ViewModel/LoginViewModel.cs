using System.ComponentModel.DataAnnotations;

namespace BookManagement.ViewModel
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}

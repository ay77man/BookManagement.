using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.ViewModel
{
    public class RegisiterViewModel
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage ="Name Is Required")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Not Like Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        [Required]
        [Remote(action: "IsEmailAvalibe", controller:"Account")]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}

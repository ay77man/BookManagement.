using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.ViewModel
{
    [Keyless]
    public class RoleViewModel
    {
      //  public string Id { get; set; }  
        [Required(ErrorMessage = "RoleName Not Entered!")]
        [Display(Name ="Role")]
        public string RoleName { get; set; }
        [Required(ErrorMessage = "Description Not Entered!")]
        public string Description { get; set; }
    }
}

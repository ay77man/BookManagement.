using BookManagement.Models;
using BookManagement.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Controllers
{
    public class AdminstrationController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;

        public AdminstrationController(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the role already exists
                bool roleExist = await roleManager.RoleExistsAsync(model.RoleName);
                if (roleExist)
                {
                    // MARK: Added an error message to the ModelState instead of returning JSON
                    ModelState.AddModelError(string.Empty, "Role already exists!");
                }
                else
                {
                    ApplicationRole role = new ApplicationRole
                    {
                        Name = model.RoleName,
                        Description = model.Description,
                        
                    };
                    var result = await roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    // MARK: Added logic to include any identity errors into ModelState
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // MARK: If validation fails or role exists, return the view with validation messages
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AllRoles()
        {
            List<ApplicationRole> roles = await roleManager.Roles.ToListAsync();
            
            return View(roles);
        }
        [HttpGet]
        
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
           
                return View("NotFound");
            }

            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                // Role deletion successful
                return RedirectToAction("AllRoles"); // Redirect to the roles list page
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            // If we reach here, something went wrong, return to the view
            return View("AllRoles", await roleManager.Roles.ToListAsync());
        }
    }
}

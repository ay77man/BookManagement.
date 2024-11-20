using BookManagement.Models;
using BookManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisiterViewModel model)
        {
            if(ModelState.IsValid)
            {
                //Mapping
                ApplicationUser applicationuser = new ApplicationUser
                {
                    UserName = model.Name,
                    Email = model.Email,
                    Adderss = model.Address
                    
                };
                
                // Create
              var result=await userManager.CreateAsync(applicationuser, model.Password);
                // SignIn
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(applicationuser, false);
                    return RedirectToAction("index","Home");
                }
                foreach(var i in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,i.Description);
                }
            }
            return View(model);

        }

        
        [AllowAnonymous]
        [HttpPost]
        [HttpGet]
        //  Used In Regesitertion to emali NOt repeat
        public async Task<IActionResult> IsEmailAvalibe(string Email)
        {
            var user = await userManager.FindByEmailAsync(Email);
            if (user == null)
            {
                return Json(true);
            }
            return Json($"The {Email} Is Exist !!");
        }
        [HttpGet]
        public IActionResult Login(string?ReturnUrl = null)
        {
            ViewData["ReturnUrl"] = ReturnUrl;    
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(LoginViewModel model,string? ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // isFoundUser
                    ApplicationUser applicationuser = await userManager.FindByEmailAsync(model.Email);
                    if (applicationuser != null)
                    {
                        // Compare Password
                        bool foundPassword = await userManager.CheckPasswordAsync(applicationuser, model.Password);
                        //SignIn
                        if (foundPassword)
                        {
                            await signInManager.SignInAsync(applicationuser, model.RememberMe);
                            if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                            {
                                return Redirect(ReturnUrl);
                            }
                            return RedirectToAction("index", "Home");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error In login");
                }

            }
            return View(model);
        }

      
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return View("Register");
        }
       
        
    }
}

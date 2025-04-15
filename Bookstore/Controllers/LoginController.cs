using Bookstore.Models;
using Bookstore.Models.DTOs.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }
  
        [HttpPost]
        public async Task<IActionResult> Login(Login_DTO login)
        {
            if (ModelState.IsValid)
            {
                AppUser user = null;

                if (login.EmailOrUserName.Contains("@"))
                    user = await _userManager.FindByEmailAsync(login.EmailOrUserName);
                else
                    user = await _userManager.FindByNameAsync(login.EmailOrUserName);

                if (user != null)
                {
                    bool isPasswordCorrect = await _userManager.CheckPasswordAsync(user, login.Password);

                    if (isPasswordCorrect)
                    {
                        await _signInManager.SignInAsync(user, false);
                        bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

                        if (isAdmin)
                        {
                            return Redirect("~/AdminPanel/Home/Index");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Panel", new { area = "UserPanel" });
                        }
                    }
                }
            }

            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}

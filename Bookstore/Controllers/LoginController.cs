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

                        var getUser = await _userManager.GetUserAsync(User);
                        var name = getUser?.Name ?? getUser?.UserName ?? "Kullanıcı";

                        if (isAdmin)
                        {
                            TempData["ToastMessage"] = $"👋 {getUser}, hoşgeldin.";
                            TempData["ToastType"] = "success";
                            return Redirect("~/AdminPanel/Home/Index");
                        }
                        else
                        {
                            TempData["ToastMessage"] = $"👋 {getUser}, hoşgeldin.";
                            TempData["ToastType"] = "success";
                            return RedirectToAction("Index", "Home", new { area = "UserPanel" });
                        }
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var user = await _userManager.GetUserAsync(User);
            var name = user?.Name ?? user?.UserName ?? "Kullanıcı";
            await _signInManager.SignOutAsync();

            TempData["ToastMessage"] = $"👋 {name}, güle güle! Tekrar bekleriz.";
            TempData["ToastType"] = "info";
            return RedirectToAction("Login", "Login");
        }
    }
}

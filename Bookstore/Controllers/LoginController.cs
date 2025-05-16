using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Models;
using Bookstore.Models.DTOs.Login;
using Bookstore.Models.DTOs.Register;
using Bookstore.Models.ViewModels.Login_VM;
using Bookstore.Models.ViewModels.Register_VM;
using Bookstore.Services.LoginService;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILoginService loginService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _loginService = loginService;
            _mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }
  
        [HttpPost]

        public async Task<IActionResult> Login(Login_VM loginVm)
        {
            if (!ModelState.IsValid)
                return View(loginVm);

            var loginDto = _mapper.Map<Login_DTO>(loginVm);
            var loginResult = await _loginService.LoginAsync(loginDto);
            if (!loginResult.Success)
            {
                ModelState.AddModelError(string.Empty, "E-posta/Kullanıcı adı veya şifre hatalı.");
                return View(loginVm);
            }

            TempData["ToastMessage"] = $"👋 {loginResult.DisplayName}, hoş geldin.";
            TempData["ToastType"] = "success";

            if (loginResult.IsAdmin)
                return RedirectToAction("Index", "Home", new { area = "AdminPanel" });

            return RedirectToAction("Index", "Home", new { area = "UserPanel" });
        }
   

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var user = await _userManager.GetUserAsync(User);
            var name = user?.Name ?? user?.UserName ?? "Kullanıcı";
            await _loginService.LogoutAsync();

            TempData["ToastMessage"] = $"👋 {name}, güle güle! Tekrar bekleriz.";
            TempData["ToastType"] = "info";
            return RedirectToAction("Login", "Login");
        }


    }
}

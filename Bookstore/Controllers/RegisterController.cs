using AutoMapper;
using Bookstore.Models;
using Bookstore.Models.DTOs.Register;
using Bookstore.Models.ViewModels.Register_VM;
using Bookstore.Services.RegisterService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterService _registerService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public RegisterController(IRegisterService registerService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _registerService = registerService;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return PartialView("~/Views/Shared/Partials/Modals/_RegisterModal.cshtml", new Register_VM());
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register_VM registerVm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("~/Views/Shared/Partials/Modals/_RegisterModal.cshtml", registerVm);
            }

            var registerDto = _mapper.Map<Register_DTO>(registerVm);
            var result = await _registerService.RegisterAsync(registerDto);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

                TempData["RegisterError"] = "Kayıt başarısız.";
                return PartialView("~/Views/Shared/Partials/Modals/_RegisterModal.cshtml", registerVm);

            }

            var user = await _userManager.FindByEmailAsync(registerDto.Email);
            if (user != null)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return Json(new { success = true, redirectUrl = Url.Action("Index", "Home", new { area = "UserPanel" }) });
        }

    }
}
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

            var RegisterDto = _mapper.Map<Register_DTO>(registerVm);
            var result = await _registerService.RegisterAsync(RegisterDto);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return PartialView("~/Views/Shared/Partials/Modals/_RegisterModal.cshtml", registerVm);
            }

            var user = await _userManager.FindByEmailAsync(RegisterDto.Email);
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Login", "Login");



        }
    }
}
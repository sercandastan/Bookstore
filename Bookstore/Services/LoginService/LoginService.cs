using AutoMapper;
using Bookstore.Models;
using Bookstore.Models.DTOs.Login;
using Microsoft.AspNetCore.Identity;

namespace Bookstore.Services.LoginService
{

    public class LoginService : ILoginService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public LoginService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        //public async Task<AppUser> LoginAsync(Login_DTO loginDto)
        //{


        //    //Find username or email
        //    bool isUserExists = false;
        //    LoginResult_DTO result = new LoginResult_DTO();
        //    result.UserId = -1;
        //    AppUser searchedUser = null;
        //    searchedUser = await _userManager.FindByNameAsync(loginDto.EmailOrUserName);

        //    if (searchedUser == null)
        //    {
        //        searchedUser = await _userManager.FindByEmailAsync(loginDto.EmailOrUserName);
        //    }
        //    if (searchedUser != null)
        //    {
        //        isUserExists = await _userManager.CheckPasswordAsync(searchedUser, loginDto.Password);
        //    }
        //    if (isUserExists)
        //    {
        //        result.UserId = searchedUser.Id;
        //        result.IsAdmin = await _userManager.IsInRoleAsync(searchedUser, "Admin");
        //    }
        //    return searchedUser;
        //}

        public async Task<LoginResult_DTO> LoginAsync(Login_DTO loginDto)
        {
            var result = new LoginResult_DTO { Success = false, UserId = -1 };

            var user = await _userManager.FindByNameAsync(loginDto.EmailOrUserName)
                ?? await _userManager.FindByEmailAsync(loginDto.EmailOrUserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                result.Success = true;
                result.UserId = user.Id;
                result.IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                result.DisplayName = !string.IsNullOrWhiteSpace(user.Name)
                                     ? user.Name
                                     : user.UserName;
            }

            return result;

        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

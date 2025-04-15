using AutoMapper;
using Bookstore.Models;
using Bookstore.Models.DTOs.Login;
using Microsoft.AspNetCore.Identity;

namespace Bookstore.Services.LoginService
{

    public class LoginService : ILoginService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public LoginService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<AppUser> LoginAsync(Login_DTO user)
        {
            //Find username or email
            bool isUserExists = false;
            LoginResult_DTO result = new LoginResult_DTO();
            result.UserId = -1;
            AppUser searchedUser = null;
            searchedUser = await _userManager.FindByNameAsync(user.EmailOrUserName);

            if (searchedUser == null)
            {
                searchedUser = await _userManager.FindByEmailAsync(user.EmailOrUserName);
            }
            if (searchedUser != null)
            {
                isUserExists = await _userManager.CheckPasswordAsync(searchedUser, user.Password);
            }
            if (isUserExists)
            {
                result.UserId = searchedUser.Id;
                result.IsAdmin = await _userManager.IsInRoleAsync(searchedUser, "Admin");
            }
            return searchedUser;
        }


        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}

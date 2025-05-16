using AutoMapper;
using Bookstore.Models;
using Bookstore.Models.DTOs.Register;
using Microsoft.AspNetCore.Identity;

namespace Bookstore.Services.RegisterService
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public RegisterService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> RegisterAsync(Register_DTO registerDto)
        {
            var user = _mapper.Map<AppUser>(registerDto);

            //user.UserName = registerDto.UserName;
            //user.NormalizedUserName = registerDto.UserName.ToUpperInvariant();
            //user.Email = registerDto.Email;
            //user.NormalizedEmail = registerDto.Email.ToUpperInvariant();
            

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
                return result;


            var roleResult = await _userManager.AddToRoleAsync(user, "User");
            if (!roleResult.Succeeded)
                return roleResult;

            return result;


        }
    }
}

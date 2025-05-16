using Bookstore.Models.DTOs.Register;
using Microsoft.AspNetCore.Identity;

namespace Bookstore.Services.RegisterService
{
    public interface IRegisterService
    {
        Task<IdentityResult> RegisterAsync(Register_DTO registerDto);
    }
}

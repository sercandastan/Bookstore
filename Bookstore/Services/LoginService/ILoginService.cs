using Bookstore.Models;
using Bookstore.Models.DTOs.Login;

namespace Bookstore.Services.LoginService
{
    public interface ILoginService
    {
        public Task<AppUser> LoginAsync(Login_DTO user);

        public Task LogoutAsync();
    }
}

namespace Bookstore.Models.DTOs.Login
{
    public class LoginResult_DTO
    {
        public bool Success { get; set; }
        public int UserId { get; set; } = -1;

        public bool IsAdmin { get; set; }

        public string DisplayName { get; set; }
    }
}

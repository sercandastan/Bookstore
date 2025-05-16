using System.Text.Json;
using Bookstore.Models.DTOs.Cart;

namespace Bookstore.Areas.UserPanel.Helpers
{
    public static class CartCookieHelper
    {
        private const string CookieName = "Bookstore.Cart";

        public static List<Cart_DTO> GetCart(this HttpRequest request)
        {
            if (!request.Cookies.TryGetValue(CookieName, out var json))
                return new List<Cart_DTO>();

            try
            {
                return JsonSerializer.Deserialize<List<Cart_DTO>>(json)
                       ?? new List<Cart_DTO>();
            }
            catch
            {
                return new List<Cart_DTO>();
            }
        }

        public static void SetCart(this HttpResponse response, List<Cart_DTO> items)
        {
            var json = JsonSerializer.Serialize(items);
            var options = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            };
            response.Cookies.Append(CookieName, json, options);
        }

        public static void ClearCart(this HttpResponse response)
            => response.Cookies.Delete(CookieName);
    }

}


using Azure.Core;
using Bookstore.Models.ViewModels.Cart_VM;
using Bookstore.Services.BookService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class CartController : Controller
{
    private readonly IBookService _bookService;

    public CartController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCartItems()
    {
        if (!Request.Cookies.TryGetValue("Bookstore.Cart", out var cookieValue)
            || string.IsNullOrWhiteSpace(cookieValue))
            return Json(new List<Cart_VM>());

        var json = Uri.UnescapeDataString(cookieValue);
        var cookieItems = JsonConvert.DeserializeObject<List<CookieCartItem>>(json);
        var cartItems = new List<Cart_VM>();

        foreach (var ci in cookieItems)
        {
            // Burada detaylı DTO’yu kullanıyoruz:
            var detail = await _bookService.GetBookDetailByIdAsync(ci.BookId);

            cartItems.Add(new Cart_VM
            {
                BookId = detail.Id,
                Title = detail.Title,
                Price = detail.Price,
                Quantity = ci.Quantity,
                CoverImage = string.IsNullOrEmpty(detail.CoverImage)
                                    ? "/BookCoverImages/defaultBookCover.png"
                                    : detail.CoverImage,


            });
        }

        return Json(cartItems);
    }

    // Yardımcı DTO:
    private class CookieCartItem
    {
        public int BookId { get; set; }
        public short Quantity { get; set; }
    }

}

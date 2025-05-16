using Bookstore.Helpers;
using Bookstore.Models.DTOs.Cart;
using Bookstore.Models.ViewModels.Cart_VM;
using Bookstore.Services.BookService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
    [AllowAnonymous]
    [Route("[controller]/[action]")]
    public class CartController : Controller
    {
        private readonly IBookService _bookService;
        public CartController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult Add(int bookId, short quantity = 1)
        {
            var cart = Request.GetCart();
            var exist = cart.FirstOrDefault(x => x.BookId == bookId);
            if (exist != null) exist.Quantity += quantity;
            else cart.Add(new Cart_DTO { BookId = bookId, Quantity = quantity });
            Response.SetCart(cart);

            // Ajax isteğiyse toast partial’ı dön
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                TempData["ToastMessage"] = "🛒 Kitap sepete eklendi.";
                TempData["ToastType"] = "info";
                return PartialView("~/Views/Shared/_ToastPartial.cshtml");
            }

            // Normal post ise eski davranış
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> GetCartItems()
        {
            var cookieCart = Request.GetCart();
            var vmList = new List<Cart_VM>();
            foreach (var dto in cookieCart)
            {
                var detail = await _bookService.GetBookDetailByIdAsync(dto.BookId);
                vmList.Add(new Cart_VM
                {
                    BookId = detail.Id,
                    Title = detail.Title,
                    Price = detail.Price,
                    Quantity = dto.Quantity,
                    CoverImage = string.IsNullOrEmpty(detail.CoverImage)
                                 ? "/BookCoverImages/defaultBookCover.png"
                                 : detail.CoverImage
                });
            }
            return Json(vmList);
        }

        [HttpPost]
        public IActionResult UpdateCartItem(int bookId, short quantity)
        {
            var cart = Request.GetCart();
            var item = cart.FirstOrDefault(x => x.BookId == bookId);
            if (item != null)
            {
                item.Quantity = quantity;
                Response.SetCart(cart);
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int bookId)
        {
            var cart = Request.GetCart();
            var item = cart.FirstOrDefault(x => x.BookId == bookId);
            if (item != null)
            {
                cart.Remove(item);
                Response.SetCart(cart);
            }
            return Ok();
        }
    }
}
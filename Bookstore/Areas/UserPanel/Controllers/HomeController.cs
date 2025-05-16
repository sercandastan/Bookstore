using Bookstore.Services.BookService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize(Roles = "User")]
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
           var books = await _bookService.GetAllBooksDetailedAsync();
            return View(books);
        }

        
    }
}

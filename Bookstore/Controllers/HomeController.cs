using Bookstore.Services.BookService;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers
{
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

using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Models;
using Bookstore.Models.ViewModels.Book_VM;
using Bookstore.Services.BookService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;


namespace Bookstore.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize(Roles = "User")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        private readonly UserManager<AppUser> _userManager;

        public BookController(IBookService bookService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _bookService = bookService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooksDetailedAsync();
            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {
            var detailsBookDto = await _bookService.GetBookDetailByIdAsync(id);
            if (detailsBookDto == null)
            {
                return NotFound();
            }
            var detailsBookVm = _mapper.Map<DetailsBook_VM>(detailsBookDto);

            return View(detailsBookVm);
        }

    }
}


using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Areas.AdminPanel.ViewModels.Book_VM;
using Bookstore.Models;
using Bookstore.Models.DTOs.Book;
using Bookstore.Services.AuthorService;
using Bookstore.Services.BookService;
using Bookstore.Services.CategoryService;
using Bookstore.Services.PublisherService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bookstore.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public BookController(IBookService bookService, ICategoryService categoryService, IAuthorService authorService, IPublisherService publisherService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _authorService = authorService;
            _publisherService = publisherService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string search)
        {
            IEnumerable<Book_DTO> books;

            if (!string.IsNullOrWhiteSpace(search))
            {
                books = await _bookService.SearchBooksAsync(search);
                ViewBag.SearchTerm = search;
            }
            else
            {
                books = await _bookService.GetAllBooksDetailedAsync();
            }

            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createBookVm = new CreateBook_VM
            {
                Authors = new SelectList(await _authorService.GetAllAuthorsAsync(), "Id", "FullName"),
                Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "Id", "CategoryName"),
                Publishers = new SelectList(await _publisherService.GetAllPublishersAsync(), "Id", "PublisherName"),
            };
            return View(createBookVm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBook_VM createBookVm)
        {


            if (ModelState.IsValid)
            {
                string fileName = null;
                if (createBookVm.CoverImage != null)
                {
                    //Kapak resmini kaydeder
                    string guid = Guid.NewGuid().ToString();
                    fileName = $"{guid}_{createBookVm.CoverImage.FileName}";
                    string path = Path.Combine("wwwroot/BookCoverImages", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await createBookVm.CoverImage.CopyToAsync(stream);
                    }
                }
                else
                {
                    fileName = "defaultBookCover.png";
                }

                //Dto'ya mapler
                var addNewBookDto = _mapper.Map<CreateBook_DTO>(createBookVm);

                //Giriş yapan kullanıcıdan ID alır
                var currentUserId = _userManager.GetUserId(User);
                addNewBookDto.UserId = currentUserId;
                // Kapak görselini setler
                addNewBookDto.CoverImage = $"/BookCoverImages/{fileName.Replace("/BookCoverImages/", "")}";

                await _bookService.AddBookAsync(addNewBookDto);

                //Toast mesajı set edilir
                TempData["ToastMessage"] = "📚 Kitap başarıyla eklendi!";
                TempData["ToastType"] = "success";



                return RedirectToAction("Index", "Book", new { area = "AdminPanel" });

            }
            var createBookvm = new CreateBook_VM
            {
                Authors = new SelectList(await _authorService.GetAllAuthorsAsync(), "Id", "FullName"),
                Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "Id", "CategoryName"),
                Publishers = new SelectList(await _publisherService.GetAllPublishersAsync(), "Id", "PublisherName"),

            };
            return View(createBookvm);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteBookAsync(id);
            //Toast mesajı set edilir
            TempData["ToastMessage"] = "📖🗑️ Kitap başarıyla silindi!";
            TempData["ToastType"] = "danger";



            return RedirectToAction("Index", "Book", new { area = "AdminPanel" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookDetailByIdAsync(id); 
            if (book == null) return NotFound();

            var updateBookVm = new UpdateBook_VM
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                PublicationYear = book.PublicationYear,
                EditionNumber = book.EditionNumber,
                CoverText = book.CoverText,
                PublisherId = book.PublisherId,
                CategoryId = book.CategoryId,
                AuthorIds = book.AuthorIds,
                Publishers = new SelectList(await _publisherService.GetAllPublishersAsync(), "Id", "PublisherName"),
                Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "Id", "CategoryName"),
                Authors = new SelectList(await _authorService.GetAllAuthorsAsync(), "Id", "FullName")
            };

            return View(updateBookVm);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBook_VM updatedBookVm)
        {
            if (!ModelState.IsValid)
            {
                updatedBookVm.Authors = new SelectList(await _authorService.GetAllAuthorsAsync(), "Id", "FullName");
                updatedBookVm.Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "Id", "CategoryName");
                updatedBookVm.Publishers = new SelectList(await _publisherService.GetAllPublishersAsync(), "Id", "PublisherName");
                return View(updatedBookVm);
            }
            var existingBook = await _bookService.GetBookDetailByIdAsync(updatedBookVm.Id);
            if (existingBook == null) return NotFound();

            string fileName;

            if (updatedBookVm.CoverImage != null)
            {
                // Eski görsel silinir (default değilse)
                if (!string.IsNullOrEmpty(existingBook.CoverImage) && !existingBook.CoverImage.Contains("defaultBookCover.png"))
                {
                    string oldImagePath = Path.Combine("wwwroot", existingBook.CoverImage.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // Yeni görsel yüklenir
                string guid = Guid.NewGuid().ToString();
                fileName = $"{guid}_{updatedBookVm.CoverImage.FileName}";
                string newPath = Path.Combine("wwwroot/BookCoverImages", fileName);

                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    await updatedBookVm.CoverImage.CopyToAsync(stream);
                }
            }
            else
            {
                // Kapak görseli yüklenmemişse mevcut görseli kullan
                fileName = Path.GetFileName(existingBook.CoverImage);
            }

            // DTO’ya maple ve kapak görselini ayarla
            var updateDTO = _mapper.Map<UpdateBook_DTO>(updatedBookVm);
            updateDTO.CoverImage = $"/BookCoverImages/{fileName}";

            // Güncelleme işlemini yap
            await _bookService.UpdateBookAsync(updateDTO);

            TempData["ToastMessage"] = "📖 Kitap başarıyla güncellendi!";
            TempData["ToastType"] = "info";

            return RedirectToAction("Index", "Book", new { area = "AdminPanel" });
        }
    }




}

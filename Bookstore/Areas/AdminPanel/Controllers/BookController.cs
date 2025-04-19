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
        private readonly IWebHostEnvironment _env;

        public BookController(
            IBookService bookService,
            ICategoryService categoryService,
            IAuthorService authorService,
            IPublisherService publisherService,
            IMapper mapper,
            UserManager<AppUser> userManager,
            IWebHostEnvironment env)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _authorService = authorService;
            _publisherService = publisherService;
            _mapper = mapper;
            _userManager = userManager;
            _env = env;
        }

        public async Task<IActionResult> Index(string search)
        {
            var books = string.IsNullOrWhiteSpace(search)
                ? await _bookService.GetAllBooksDetailedAsync()
                : await _bookService.SearchBooksAsync(search);

            ViewBag.SearchTerm = search;
            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new CreateBook_VM();
            await PopulateSelectListsAsync(vm);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBook_VM vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateSelectListsAsync(vm);
                return View(vm);
            }

            string fileName;

            try
            {
                if (vm.CoverImage != null && vm.CoverImage.Length > 0)
                {
                    var extension = Path.GetExtension(vm.CoverImage.FileName);
                    fileName = $"{Guid.NewGuid()}{extension}";
                    var path = Path.Combine(_env.WebRootPath, "BookCoverImages", fileName);

                    using var stream = new FileStream(path, FileMode.Create);
                    await vm.CoverImage.CopyToAsync(stream);
                }
                else
                {
                    fileName = "defaultBookCover.png";
                }
            }
            catch (Exception ex)
            {
                // Hata yakalama
                ModelState.AddModelError("", "Görsel yüklenirken hata oluştu: " + ex.Message);
                await PopulateSelectListsAsync(vm);
                return View(vm);
            }

            var dto = _mapper.Map<CreateBook_DTO>(vm);
            dto.UserId = _userManager.GetUserId(User);
            dto.CoverImage = $"/BookCoverImages/{fileName}";

            await _bookService.AddBookAsync(dto);

            TempData["ToastMessage"] = "📚 Kitap başarıyla eklendi!";
            TempData["ToastType"] = "success";

            return RedirectToAction("Index");
        }




        //[HttpPost]
        //public async Task<IActionResult> Create(CreateBook_VM vm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        await PopulateSelectListsAsync(vm);
        //        return View(vm);
        //    }

        //    string fileName = "defaultBookCover.png";
        //    string uploadDir = Path.Combine(_env.WebRootPath, "BookCoverImages");

        //    if (!Directory.Exists(uploadDir))
        //        Directory.CreateDirectory(uploadDir);

        //    if (vm.CoverImage != null && vm.CoverImage.Length > 0)
        //    {
        //        try
        //        {
        //            string extension = Path.GetExtension(vm.CoverImage.FileName);
        //            fileName = $"{Guid.NewGuid()}{extension}";
        //            string path = Path.Combine(uploadDir, fileName);

        //            using var stream = new FileStream(path, FileMode.Create);
        //            await vm.CoverImage.CopyToAsync(stream);
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("", "Kapak görseli yüklenemedi. Lütfen tekrar deneyin.");
        //            await PopulateSelectListsAsync(vm);
        //            return View(vm);
        //        }
        //    }

        //    var dto = _mapper.Map<CreateBook_DTO>(vm);
        //    dto.UserId = _userManager.GetUserId(User);
        //    dto.CoverImage = $"/BookCoverImages/{fileName}";

        //    await _bookService.AddBookAsync(dto);

        //    TempData["ToastMessage"] = "📚 Kitap başarıyla eklendi!";
        //    TempData["ToastType"] = "success";

        //    return RedirectToAction("Index");
        //}



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookDetailByIdAsync(id);
            if (book == null) return NotFound();

            var vm = _mapper.Map<UpdateBook_VM>(book);
            vm.ExistingCoverImagePath = book.CoverImage;
            await PopulateSelectListsAsync(vm);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBook_VM vm)
        {
            if (vm.AuthorIds == null || !vm.AuthorIds.Any())
                ModelState.AddModelError(nameof(vm.AuthorIds), "En az bir yazar seçilmelidir.");

            if (!ModelState.IsValid)
            {
                await PopulateSelectListsAsync(vm);
                return View(vm);
            }

            var existingBook = await _bookService.GetBookDetailByIdAsync(vm.Id);
            if (existingBook == null) return NotFound();

            string fileName;

            if (vm.CoverImage != null && vm.CoverImage.Length > 0)
            {
                var isDefault = string.IsNullOrEmpty(existingBook.CoverImage) || existingBook.CoverImage.EndsWith("defaultBookCover.png");

                if (!isDefault)
                {
                    var oldPath = Path.Combine(_env.WebRootPath, existingBook.CoverImage.TrimStart('/'));
                    if (System.IO.File.Exists(oldPath))
                        System.IO.File.Delete(oldPath);
                }

                var extension = Path.GetExtension(vm.CoverImage.FileName);
                fileName = $"{Guid.NewGuid()}{extension}";
                var newPath = Path.Combine(_env.WebRootPath, "BookCoverImages", fileName);

                try
                {
                    using var stream = new FileStream(newPath, FileMode.Create);
                    await vm.CoverImage.CopyToAsync(stream);
                }
                catch
                {
                    await PopulateSelectListsAsync(vm);
                    ModelState.AddModelError("", "Görsel yüklenirken bir hata oluştu.");
                    return View(vm);
                }
            }
            else
            {
                fileName = Path.GetFileName(existingBook.CoverImage);
            }

            var dto = _mapper.Map<UpdateBook_DTO>(vm);
            dto.CoverImage = $"/BookCoverImages/{fileName}";

            await _bookService.UpdateBookAsync(dto);

            TempData["ToastMessage"] = "📖 Kitap başarıyla güncellendi!";
            TempData["ToastType"] = "info";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetBookDetailByIdAsync(id);
            if (book == null)
            {
                TempData["ToastMessage"] = "❌ Kitap bulunamadı.";
                TempData["ToastType"] = "warning";
                return RedirectToAction("Index");
            }

            if (!string.IsNullOrEmpty(book.CoverImage) && !book.CoverImage.EndsWith("defaultBookCover.png"))
            {
                var imagePath = Path.Combine(_env.WebRootPath, book.CoverImage.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                    System.IO.File.Delete(imagePath);
            }

            await _bookService.DeleteBookAsync(id);

            TempData["ToastMessage"] = "📖🗑️ Kitap başarıyla silindi!";
            TempData["ToastType"] = "danger";

            return RedirectToAction("Index");
        }

        private async Task PopulateSelectListsAsync(Book_VM vm)
        {
            vm.Authors = new SelectList(await _authorService.GetAllAuthorsAsync(), "Id", "FullName", vm.AuthorIds);
            vm.Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "Id", "CategoryName", vm.CategoryId);
            vm.Publishers = new SelectList(await _publisherService.GetAllPublishersAsync(), "Id", "PublisherName", vm.PublisherId);
        }
    }
}

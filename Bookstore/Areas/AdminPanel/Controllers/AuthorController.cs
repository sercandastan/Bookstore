using AutoMapper;
using Bookstore.Areas.AdminPanel.ViewModels.Author_VM;
using Bookstore.Areas.AdminPanel.ViewModels.Publisher_VM;
using Bookstore.Models.DTOs.Author;
using Bookstore.Services.AuthorService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public async Task< IActionResult> Index()
        {
            var fetchedAuthors = await _authorService.GetAllAuthorsAsync();
            return View(fetchedAuthors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthor_VM createAuthorVm)
        {
            if(!ModelState.IsValid) return View(createAuthorVm);

            var createAuthorDto = _mapper.Map<CreateAuthor_DTO>(createAuthorVm);

            await _authorService.CreateAuthorAsync(createAuthorDto);

            TempData["ToastMessage"] = "🖋️  Yazar başarıyla oluşturuldu.";
            TempData["ToastType"] = "success";

            return RedirectToAction("Index", "Author", new { area = "AdminPanel" });

        }
        //modal için
        [HttpPost]
        public async Task<IActionResult> CreateAjax([FromForm] CreateAuthor_VM createAuthorVm)
        {
            if (!ModelState.IsValid) return BadRequest("Geçersiz Veri");

            var createAuthorDto = _mapper.Map<CreateAuthor_DTO>(createAuthorVm);

           var newAuthorId = await  _authorService.CreateAuthorAsync(createAuthorDto);
            return Json(new {success= true, id = newAuthorId, name = createAuthorVm.FullName});
        }

        [HttpGet]

        public async Task<IActionResult> Edit (int id)
        {
            var authorDto = await _authorService.GetAuthorByIdAsync(id);
            if(authorDto == null) return NotFound();

            var authorVm = _mapper.Map<UpdateAuthor_VM>(authorDto);
            return View(authorVm);
        }
        [HttpPost]

        public async Task <IActionResult> Edit (UpdateAuthor_VM updateAuthorVm)
        {
            if(!ModelState.IsValid) return View(updateAuthorVm);

            var updateAuthorDto = _mapper.Map<UpdateAuthor_DTO>(updateAuthorVm);

            var result = await _authorService.UpdateAuthorAsync(updateAuthorDto);
            if (result)
            {
                TempData["ToastMessage"] = "✍️  Yazar başarıyla güncellendi";
                TempData["ToastType"] = "info";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Yazar güncellenirken bir hata oluştu.");
            return View(updateAuthorVm);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            TempData["ToastMessage"] = "🖋️ 🗑️ Yazar başarıyla silindi";
            TempData["ToastType"] = "danger";

            return RedirectToAction("Index", "Author", new { area = "AdminPanel" });
        }
    }
}

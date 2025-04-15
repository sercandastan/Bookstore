using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Areas.AdminPanel.ViewModels.Category_VM;
using Bookstore.Models.DTOs.Category;
using Bookstore.Services.CategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategory_VM newCategory)
        {
            if (!ModelState.IsValid)
                return View(newCategory);

            var createNewCategoryDto = _mapper.Map<CreateCategory_DTO>(newCategory);
            await _categoryService.CreateCategoryAsync(createNewCategoryDto);

            TempData["ToastMessage"] = "🗂️ Kategori başarıyla oluşturuldu.";
            TempData["ToastType"] = "success";

            return RedirectToAction("Index", "Category", new { area = "AdminPanel" });
        }

        //modal için
        [HttpPost]
        public async Task<IActionResult> CreateAjax([FromForm] CreateCategory_VM createCategoryVm)
        {
            if (!ModelState.IsValid)
                return BadRequest("Gecersiz veri.");

            var createCategoryDto = _mapper.Map<CreateCategory_DTO>(createCategoryVm);
            var newCategoryId = await _categoryService.CreateCategoryAsync(createCategoryDto);

            return Json(new {success=true, id= newCategoryId, name = createCategoryVm.CategoryName });
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categoryDto = await _categoryService.GetCategoryByIdAsync(id);
            if (categoryDto == null) return NotFound();

            var categoryVm = _mapper.Map<UpdateCategory_VM>(categoryDto);

            return View(categoryVm);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCategory_VM updatedCategoryVm)
        {
            if (!ModelState.IsValid)  return View(updatedCategoryVm);

            var updateCategoryDto = _mapper.Map<UpdateCategory_DTO>(updatedCategoryVm);

            var result = await _categoryService.UpdateCategoryAsync(updateCategoryDto);

            if (result)
            {
                TempData["ToastMessage"] = "📂 Kategori başarıyla güncellendi!";
                TempData["ToastType"] = "info";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Kategori güncellenirken bir hata oluştu.");
            return View(updatedCategoryVm);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            TempData["ToastMessage"] = "🗂️🗑️ Kategori başarıyla silindi!";
            TempData["ToastType"] = "danger";
            return RedirectToAction("Index", "Category", new { area = "AdminPanel" });


        }



    }
}

using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Areas.AdminPanel.ViewModels.Publisher_VM;
using Bookstore.Models.DTOs.Publisher;
using Bookstore.Services.PublisherService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin")]
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;
        private readonly IMapper _mapper;

        public PublisherController(IPublisherService publisherService, IMapper mapper)
        {
            _publisherService = publisherService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var publishers = await _publisherService.GetAllPublishersAsync();
            return View(publishers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePublisher_VM newPublisher)
        {
            if (!ModelState.IsValid)
                return View(newPublisher);

            var createPublisherDto = _mapper.Map<CreatePublisher_DTO>(newPublisher);
            await _publisherService.CreatePublisherAsync(createPublisherDto);

            TempData["ToastMessage"] = "✅ Yayınevi başarıyla oluşturuldu.";
            TempData["ToastType"] = "success";

            return RedirectToAction("Index", "Publisher", new { area = "AdminPanel" });
        }
        [HttpPost]
        public async Task<IActionResult> CreateAjax([FromForm] CreatePublisher_VM createPublisherVm)
        {
            if (!ModelState.IsValid) return BadRequest("Geçersiz veri.");

            var createPublisherDto = _mapper.Map<CreatePublisher_DTO>(createPublisherVm);
            var newPublisherId = await _publisherService.CreatePublisherAsync(createPublisherDto);

            return Json(new {success=true, id= newPublisherId ,name = createPublisherVm.PublisherName });
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var publisherDto = await _publisherService.GetPublisherByIdAsync(id);
            if (publisherDto == null) return NotFound();

            var publisherVm = _mapper.Map<UpdatePublisher_VM>(publisherDto);

            return View(publisherVm);

        }
        [HttpPost]

        public async Task<IActionResult> Edit(UpdatePublisher_VM updatedPublisherVm)
        {
            if (!ModelState.IsValid) return View(updatedPublisherVm);

            var updatePublisherDto = _mapper.Map<UpdatePublisher_DTO>(updatedPublisherVm);

            var result = await _publisherService.UpdatePublisherAsync(updatePublisherDto);
            if (result)
            {
                TempData["ToastMessage"] = "🏢 Yayınevi başarıyla güncellendi";
                TempData["ToastType"] = "info";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Yayınevi güncellenirken bir hata oluştu.");
            return View(updatedPublisherVm);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _publisherService.DeletePublisherAsync(id);
            TempData["ToastMessage"] = "🏢🗑️ Yayınevi başarıyla silindi";
            TempData["ToastType"] = "danger";

            return RedirectToAction("Index", "Publisher", new { area = "AdminPanel" });
        }
    }
}

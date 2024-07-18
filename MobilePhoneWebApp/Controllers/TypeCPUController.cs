using Microsoft.AspNetCore.Mvc;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Services.Implementations;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;

namespace MobilePhoneWebApp.Controllers
{
    public class TypeCPUController : Controller
    {
        private readonly ITypeCPUService _typeCPUService;
        public TypeCPUController(ITypeCPUService typeCPUService)
        {
             _typeCPUService = typeCPUService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var TypeCPUs = await _typeCPUService.GetAllAsync();

            return View(TypeCPUs);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TypeCPUDto typeCPUDto)
        {
            if (ModelState.IsValid)
            {
                await _typeCPUService.AddAsync(typeCPUDto);

                return RedirectToAction("Index", "TypeCPU");
            }

            return View(typeCPUDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var typeCPUs = await _typeCPUService.GetByIdAsync(id);

            return View(typeCPUs);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(TypeCPUDto typeCPUDto)
        {
            if (ModelState.IsValid)
            {
                await _typeCPUService.UpdateAsync(typeCPUDto);

                return RedirectToAction("Index", "TypeCPU");
            }

            return View(typeCPUDto);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var typeCPUs = await _typeCPUService.GetByIdAsync(id);

            return View(typeCPUs);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TypeCPUDto typeCPUDto)
        {
            if (ModelState.IsValid)
            {
                await _typeCPUService.DeleteAsync(typeCPUDto.Id);

                return RedirectToAction("Index", "TypeCPU");
            }

            return View(typeCPUDto);
        }
    }

}
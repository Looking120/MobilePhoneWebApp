using Microsoft.AspNetCore.Mvc;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Services.Implementations;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;
using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.Controllers
{
    public class ManufactureController: Controller
    {
        private readonly IManufactureService _manufactureService;
        public ManufactureController(IManufactureService manufactureService)
        {
            _manufactureService = manufactureService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var manufactures = await _manufactureService.GetAllAsync();

            return View(manufactures);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ManufactureDto manufactureDto)
        {
            if (ModelState.IsValid)
            {
                await _manufactureService.AddAsync(manufactureDto);

                return RedirectToAction("Index", "Manufacture");
            }

            return View(manufactureDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var manufactures = await _manufactureService.GetByIdAsync(id);

            return View(manufactures);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ManufactureDto manufactureDto)
        {
            if (ModelState.IsValid)
            {
                await _manufactureService.UpdateAsync(manufactureDto);

                return RedirectToAction("Index", "Manufacture");
            }

            return View(manufactureDto);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var manufactures = await _manufactureService.GetByIdAsync(id);

            return View(manufactures);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ManufactureDto manufactureDto)
        {
            if (ModelState.IsValid)
            {
                await _manufactureService.DeleteAsync(manufactureDto.Id);

                return RedirectToAction("Index", "Manufacture");
            }

            return View(manufactureDto);
        }
    }

}

using Microsoft.AspNetCore.Mvc;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Services.Implementations;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;

namespace MobilePhoneWebApp.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cities = await _cityService.GetAllAsync();

            return View(cities);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CityDto cityDto)
        {
            if (ModelState.IsValid)
            {
                await _cityService.AddAsync(cityDto);

                return RedirectToAction("Index", "City");
            }

            return View(cityDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cities = await _cityService.GetByIdAsync(id);

            return View(cities);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(CityDto cityDto)
        {
            if (ModelState.IsValid)
            {
                await _cityService.UpdateAsync(cityDto);

                return RedirectToAction("Index", "City");
            }

            return View(cityDto);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var cities = await _cityService.GetByIdAsync(id);

            return View(cities);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CityDto cityDto)
        {
            if (ModelState.IsValid)
            {
                await _cityService.DeleteAsync(cityDto.Id);

                return RedirectToAction("Index", "City");
            }

            return View(cityDto);
        }
    }

}


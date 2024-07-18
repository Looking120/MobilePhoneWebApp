using Microsoft.AspNetCore.Mvc;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Services.Implementations;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;

namespace MobilePhoneWebApp.Controllers
{
    public class CountryController: Controller
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var countries = await _countryService.GetAllAsync();

            return View(countries);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CountryDto countryDto)
        {
            if (ModelState.IsValid)
            {
                await _countryService.AddAsync(countryDto);

                return RedirectToAction("Index", "Country");
            }

            return View(countryDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var countries = await _countryService.GetByIdAsync(id);

            return View(countries);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(CountryDto countryDto)
        {
            if (ModelState.IsValid)
            {
                await _countryService.UpdateAsync(countryDto);

                return RedirectToAction("Index", "Country");
            }

            return View(countryDto);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var countries = await _countryService.GetByIdAsync(id);

            return View(countries);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CountryDto countryDto)
        {
            if (ModelState.IsValid)
            {
                await _countryService.DeleteAsync(countryDto.Id);

                return RedirectToAction("Index", "Country");
            }

            return View(countryDto);
        }
    }

}
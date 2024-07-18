using Microsoft.AspNetCore.Mvc;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Services.Implementations;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;
using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.Controllers
{
    public class MobilePhoneController: Controller
    {
        private readonly IMobilePhoneService _mobilePhoneService;
        public MobilePhoneController(IMobilePhoneService mobilePhoneService)
        {
            _mobilePhoneService = mobilePhoneService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var mobilePhones = await _mobilePhoneService.GetAllAsync();

            return View(mobilePhones);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MobilePhoneDto mobilePhoneDto)
        {
            if (ModelState.IsValid)
            {
                await _mobilePhoneService.AddAsync(mobilePhoneDto);

                return RedirectToAction("Index", "MobilePhone");
            }

            return View(mobilePhoneDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var mobilePhones = await _mobilePhoneService.GetByIdAsync(id);

            return View(mobilePhones);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(MobilePhoneDto mobilePhoneDto)
        {
            if (ModelState.IsValid)
            {
                await _mobilePhoneService.UpdateAsync(mobilePhoneDto);

                return RedirectToAction("Index", "MobilePhone");
            }

            return View(mobilePhoneDto);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var mobilePhones = await _mobilePhoneService.GetByIdAsync(id);

            return View(mobilePhones);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MobilePhoneDto mobilePhoneDto)
        {
            if (ModelState.IsValid)
            {
                await _mobilePhoneService.DeleteAsync(mobilePhoneDto.Id);

                return RedirectToAction("Index", "MobilePhone");
            }

            return View(mobilePhoneDto);
        }
    }

}


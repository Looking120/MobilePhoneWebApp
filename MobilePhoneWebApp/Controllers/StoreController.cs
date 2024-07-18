using Microsoft.AspNetCore.Mvc;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Services.Implementations;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;
using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stores = await _storeService.GetAllAsync();

            return View(stores);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StoreDto storeDto)
        {
            if (ModelState.IsValid)
            {
                await _storeService.AddAsync(storeDto);

                return RedirectToAction("Index", "Store");
            }

            return View(storeDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var stores = await _storeService.GetByIdAsync(id);

            return View(stores);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(StoreDto storeDto)
        {
            if (ModelState.IsValid)
            {
                await _storeService.UpdateAsync(storeDto);

                return RedirectToAction("Index", "Store");
            }

            return View(storeDto);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var stores = await _storeService.GetByIdAsync(id);

            return View(stores);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(StoreDto storeDto)
        {
            if (ModelState.IsValid)
            {
                await _storeService.DeleteAsync(storeDto.Id);

                return RedirectToAction("Index", "Store");
            }

            return View(storeDto);
        }
    }

}
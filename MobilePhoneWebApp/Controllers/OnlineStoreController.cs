using Microsoft.AspNetCore.Mvc;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Services.Implementations;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;

namespace MobilePhoneWebApp.Controllers
{
    public class OnlineStoreController : Controller
    {
        private readonly IOnlineStoreService _onlineStoreService;
        public OnlineStoreController(IOnlineStoreService onlineStoreService)
        {
            _onlineStoreService = onlineStoreService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var onlineStores = await _onlineStoreService.GetAllAsync();

            return View(onlineStores);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OnlineStoreDto onlineStoreDto)
        {
            if (ModelState.IsValid)
            {
                await _onlineStoreService.AddAsync(onlineStoreDto);

                return RedirectToAction("Index", "OnlineStore");
            }

            return View(onlineStoreDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var onlineStores = await _onlineStoreService.GetByIdAsync(id);

            return View(onlineStores);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(OnlineStoreDto onlineStoreDto)
        {
            if (ModelState.IsValid)
            {
                await _onlineStoreService.UpdateAsync(onlineStoreDto);

                return RedirectToAction("Index", "OnlineStore");
            }

            return View(onlineStoreDto);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var onlineStores = await _onlineStoreService.GetByIdAsync(id);

            return View(onlineStores);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OnlineStoreDto onlineStoreDto)
        {
            if (ModelState.IsValid)
            {
                await _onlineStoreService.DeleteAsync(onlineStoreDto.Id);

                return RedirectToAction("Index", "OnlineStore");
            }

            return View(onlineStoreDto);
        }
    }

}


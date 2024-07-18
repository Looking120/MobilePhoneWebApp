using Microsoft.AspNetCore.Mvc;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Services.Implementations;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;

namespace MobilePhoneWebApp.Controllers
{
    public class CPUController : Controller
    {
        private readonly ICPUService _cpuService;
        public CPUController(ICPUService cpuService)
        {
            _cpuService = cpuService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cities = await _cpuService.GetAllAsync();

            return View(cities);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CPUDto cpuDto)
        {
            if (ModelState.IsValid)
            {
                await _cpuService.AddAsync(cpuDto);

                return RedirectToAction("Index", "CPU");
            }

            return View(cpuDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cpus = await _cpuService.GetByIdAsync(id);

            return View(cpus);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(CPUDto cpuDto)
        {
            if (ModelState.IsValid)
            {
                await _cpuService.UpdateAsync(cpuDto);

                return RedirectToAction("Index", "CPU");
            }

            return View(cpuDto);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var cpus = await _cpuService.GetByIdAsync(id);

            return View(cpus);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CPUDto cpuDto)
        {
            if (ModelState.IsValid)
            {
                await _cpuService.DeleteAsync(cpuDto.Id);

                return RedirectToAction("Index", "CPU");
            }

            return View(cpuDto);
        }
    }

}

using Microsoft.AspNetCore.Mvc;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;
using MobilePhoneWebApp.BusinessLogic.Dtos;

namespace MobilePhoneWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllAsync();

            return View(customers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                await _customerService.AddAsync(customerDto);

                return RedirectToAction("Index", "Customer");
            }

            return View(customerDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);

            return View(customer);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {
                await _customerService.UpdateAsync(customerDto);

                return RedirectToAction("Index", "Customer");
            }

            return View(customerDto);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                await _customerService.DeleteAsync(customerDto.Id);

                return RedirectToAction("Index", "Customer");
            }

            return View(customerDto);
        }
    }

}

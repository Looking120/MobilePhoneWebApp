using Microsoft.AspNetCore.Mvc;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Services.Implementations;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;

namespace MobilePhoneWebApp.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sales = await _saleService.GetAllAsync();

            return View(sales);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaleDto saleDto)
        {
            //check modelstate
            if (ModelState.IsValid)
            {
                await _saleService.AddAsync(saleDto);

                return RedirectToAction("Index", "Sale");
            }

            return View(saleDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var sales = await _saleService.GetByIdAsync(id);

            return View(sales);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(SaleDto saleDto)
        {
            if (ModelState.IsValid)
            {
                await _saleService.UpdateAsync(saleDto);

                return RedirectToAction("Index", "Sale");
            }

            return View(saleDto);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var sales = await _saleService.GetByIdAsync(id);

            return View(sales);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SaleDto saleDto)
        {
            if (ModelState.IsValid)
            {
                await _saleService.DeleteAsync(saleDto.Id);

                return RedirectToAction("Index", "Sale");
            }

            return View(saleDto);
        }
        [HttpGet]
        public IActionResult Task()
        {
            return View();
        }
        [HttpGet]
        public IActionResult OnlineSales()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OnlineSales(SaleDto saleDto)
        {
            if(ModelState.IsValid) 
            {
                saleDto.OnlineSales = await _saleService.GetOnlineStoreSalesByTime(saleDto.StartDate.Value,saleDto.EndDate.Value,saleDto.OnlineStoreId);
            }

            return View(saleDto);
        }

        [HttpGet]
        public IActionResult StoreSales()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StoreSales(SaleDto saleDto)
        {
            if (ModelState.IsValid)
            {
                saleDto.StoreSales = await _saleService.GetStoreSalesByTime(saleDto.StartDate.Value, saleDto.EndDate.Value, saleDto.StoreId);
            }

            return View(saleDto);
        }


        [HttpGet]
        public IActionResult CitySales()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CitySales(SaleDto saleDto)
        {
            if (ModelState.IsValid)
            {
                saleDto.CitySales = await _saleService.GetSalesForEachCity(saleDto.Store.CityId);
            }

            return View(saleDto);
        }

        [HttpGet]
        public IActionResult PopularPhone()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PopularPhone(SaleDto saleDto)
        {
            if (!ModelState.IsValid)
            {
                saleDto.MostPopularPhoneModel = await _saleService.GetTheMostPopularPhoneByCity(saleDto.Store.CityId);
            }

            return View(saleDto);
        }
        [HttpGet]
        public IActionResult UnPopularPhone()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UnPopularPhone(SaleDto saleDto)
        {
            if (!ModelState.IsValid)
            {
                saleDto.UnPopularPhoneModel = await _saleService.GetTheMostUnPopularPhoneByCity(saleDto.Store.CityId);
            }

            return View(saleDto);
        }

       

    }

}


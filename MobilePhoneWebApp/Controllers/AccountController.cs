using Microsoft.AspNetCore.Mvc;
using MobilePhoneWebApp.BusinessLogic.Dtos;
using MobilePhoneWebApp.BusinessLogic.Services.Interfaces;

namespace MobilePhoneWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public AccountController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            userDto = await _userService.GetByIdAsync(userDto.Id);
            if (userDto == null) 
            {
                return View(userDto);
            }

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}

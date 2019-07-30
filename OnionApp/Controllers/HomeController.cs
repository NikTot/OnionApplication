using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OA.Service.Interfaces;
using OA.Service.Models;
using OnionApp.Models;

namespace OnionApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }           
            
            _userService.CreateUserAsync(user);
            return Redirect("Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

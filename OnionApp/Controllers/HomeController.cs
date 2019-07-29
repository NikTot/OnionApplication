using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OA.Service.Interfaces;
using OA.Web.Models;
using OnionApp.Models;
using AutoMapper;
using OA.Data;

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
        public IActionResult Index(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }
            
            var user = Mapper.Map<UserViewModel, User>(userViewModel);
            _userService.CreateUser(user);
            return Redirect("Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

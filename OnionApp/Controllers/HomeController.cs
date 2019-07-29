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
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public HomeController(IUserService userService, ICityService cityService, IMapper mapper)
        {
            _userService = userService;
            _cityService = cityService;
            _mapper = mapper;
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
            var user = _mapper.Map<UserViewModel, User>(userViewModel);
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

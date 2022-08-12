using Cakeful.Models;
using Cakeful.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cakeful.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICakeRepository _cakeRepository;

        public HomeController(ICakeRepository cakeRepository)
        {
            _cakeRepository = cakeRepository;
        }
        public IActionResult Index()
        {
            var featuredCakes = _cakeRepository.GetFeaturedCakes();
            ViewBag.Active = "Home";
            return View(featuredCakes);
        }
    }
}
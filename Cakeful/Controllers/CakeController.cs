using Cakeful.Models;
using Cakeful.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cakeful.Controllers
{
    public class CakeController : Controller
    {
        private readonly ICakeRepository _cakeRepository;

        public CakeController(ICakeRepository cakeRepository)
        {
            _cakeRepository = cakeRepository;
        }

        public IActionResult Index(string? category)
        {
            List<Cake> cakes;
            if (string.IsNullOrEmpty(category))
            {
                cakes = _cakeRepository.Cakes.OrderBy(c => c.CakeId).ToList();
            } 
            else
            {
                cakes = _cakeRepository.Cakes.Where(c => c.Category.CategoryName == category).OrderBy(c => c.CakeId).ToList();
            }
            ViewBag.Active = "Cake";
            return View(cakes);
        }

        public IActionResult Details(int? cakeId)
        {
            if (cakeId == null)
            {
                return NotFound();
            }
            var cake = _cakeRepository.GetCake(cakeId);
            if (cake == null)
            {
                return NotFound();
            }
            return View(cake);
        }
    }
}

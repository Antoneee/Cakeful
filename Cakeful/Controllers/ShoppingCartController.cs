using Cakeful.Repositories;
using Cakeful.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cakeful.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly ICakeRepository _cakeRepository;

        public ShoppingCartController(IShoppingCart shoppingCart, ICakeRepository cakeRepository)
        {
            _shoppingCart = shoppingCart;
            _cakeRepository = cakeRepository;
        }

        public IActionResult Index()
        {
            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = shoppingCartItems;
            var totalPrice = _shoppingCart.GetCartPrice();
            var shoppingCartViewModel = new ShoppingCartViewModel(shoppingCartItems, totalPrice);
            return View(shoppingCartViewModel);
        }

        public IActionResult AddToCart(int? cakeId)
        {
            var cakeToAdd = _cakeRepository.GetCake(cakeId);
            
            if (cakeToAdd == null)
            {
                return NotFound();
            }

            _shoppingCart.AddToCart(cakeToAdd);
            return RedirectToAction("Index");
        }
    }
}

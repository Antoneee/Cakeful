using Cakeful.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cakeful.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var shoppingCartCount = _shoppingCart.GetShoppingCartItems().Select(c => c.Amount).Sum();
            return View(shoppingCartCount);
        }
    }
}

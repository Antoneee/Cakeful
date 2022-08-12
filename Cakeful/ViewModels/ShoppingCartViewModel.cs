using Cakeful.Models;

namespace Cakeful.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(IEnumerable<ShoppingCartItem> shoppingCartItems, decimal shoppingCartPrice)
        {
            ShoppingCartItems = shoppingCartItems;
            ShoppingCartPrice = shoppingCartPrice;
        }

        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
        public decimal ShoppingCartPrice { get; set; }
    }
}

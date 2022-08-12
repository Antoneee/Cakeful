using Cakeful.Models;

namespace Cakeful.Repositories
{
    public interface IShoppingCart
    {
        string ShoppingCartId { get; set; }
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
        List<ShoppingCartItem> GetShoppingCartItems();
        void AddToCart(Cake cakeToAdd);
        int RemoveFromCart(Cake cakeToRemove);
        void ClearCart();
        decimal GetCartPrice();
    }
}

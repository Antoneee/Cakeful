using Cakeful.Models;
using Microsoft.EntityFrameworkCore;

namespace Cakeful.Repositories
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly CakefulDbContext _cakefulDbContext;
        public string? ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        public ShoppingCart(CakefulDbContext cakefulDbContext)
        {
            _cakefulDbContext = cakefulDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider serviceProvider)
        {
            ISession? session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            CakefulDbContext cakefulDbContext = serviceProvider.GetRequiredService<CakefulDbContext>();

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(cakefulDbContext) { ShoppingCartId = cartId };
        }

        public void AddToCart(Cake cakeToAdd)
        {
            var existingCake = _cakefulDbContext.ShoppingCartItems
                .SingleOrDefault(c => c.Cake.CakeId == cakeToAdd.CakeId && c.ShoppingCartId == ShoppingCartId);

            if (existingCake != null)
            {
                existingCake.Amount++;
            } else
            {
                existingCake = new ShoppingCartItem
                {
                    Cake = cakeToAdd,
                    Amount = 1,
                    ShoppingCartId = ShoppingCartId
                };
                _cakefulDbContext.ShoppingCartItems.Add(existingCake);
            }
            _cakefulDbContext.SaveChanges();
        }

        public void ClearCart()
        {
            var cakesInCartList = _cakefulDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId);
            _cakefulDbContext.ShoppingCartItems.RemoveRange(cakesInCartList);
            _cakefulDbContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??= _cakefulDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(c => c.Cake).Include(c => c.Cake.Category).ToList();
        }

        public int RemoveFromCart(Cake cakeToRemove)
        {
            var existingCake = _cakefulDbContext.ShoppingCartItems
                .SingleOrDefault(c => c.Cake.CakeId == cakeToRemove.CakeId && c.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (existingCake != null)
            {
                if (existingCake.Amount > 1)
                {
                    existingCake.Amount--;
                    localAmount = existingCake.Amount;
                } else
                {
                    _cakefulDbContext.ShoppingCartItems.Remove(existingCake);
                }
            }
            _cakefulDbContext.SaveChanges();

            return localAmount;
        }

        public decimal GetCartPrice()
        {
            var cartPrice = ShoppingCartItems.Select(c => c.Amount * c.Cake.Price).Sum();
            return cartPrice;
        }
    }
}

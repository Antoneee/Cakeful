using Cakeful.Models;

namespace Cakeful.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CakefulDbContext _cakefulDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(CakefulDbContext cakefulDbContext, IShoppingCart shoppingCart)
        {
            _cakefulDbContext = cakefulDbContext;
            _shoppingCart = shoppingCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            List<ShoppingCartItem> shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            order.OrderTotal = _shoppingCart.GetCartPrice();
            order.OrderDetails = new List<OrderDetail>();
            foreach(ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    Price = shoppingCartItem.Cake.Price,
                    CakeId = shoppingCartItem.Cake.CakeId
                };

                order.OrderDetails.Add(orderDetail);
            }
            _cakefulDbContext.Orders.Add(order);
            _cakefulDbContext.SaveChanges();
        }
    }
}

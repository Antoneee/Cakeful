using Cakeful.Models;

namespace Cakeful.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}

using System.Linq;

namespace SportsStore.Models.Interface
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}

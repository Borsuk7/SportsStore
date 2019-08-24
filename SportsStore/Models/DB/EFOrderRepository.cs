using Microsoft.EntityFrameworkCore;
using SportsStore.Models.Interface;
using System.Linq;

namespace SportsStore.Models.DB
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        public EFOrderRepository(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IQueryable<Order> Orders => context.Orders
                                                  .Include(o => o.Lines)
                                                  .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.ID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}

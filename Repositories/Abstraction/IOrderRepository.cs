
using basitsatinalimuyg.Entities;

namespace basitsatinalimuyg.Repositories.Abstraction
{
  public interface IOrderRepository : IRepository<Order>
  {
    Task<ICollection<Order>?> GetOrdersByUserId(Guid id);
  }
}
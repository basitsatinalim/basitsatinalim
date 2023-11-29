

using basitsatinalimuyg.Entities;

namespace basitsatinalimuyg.Services.Abstraction
{
  public interface IOrderService
  {
    Task DeleteOrder(Guid orderId);
    Task<ICollection<Order>?> GetOrdersByUserId(Guid id);
    Task SaveOrder(Order order);
  }
}

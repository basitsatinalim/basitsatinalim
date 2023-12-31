using AutoMapper;
using basitsatinalimuyg.Context;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Repositories.Abstraction;
using basitsatinalimuyg.Services.Abstraction;

namespace basitsatinalimuyg.Services
{
  public class OrderService : IOrderService
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderLineRepository _orderLineRepository;

    public OrderService(IUnitOfWork unitOfWork, IOrderRepository orderRepository, IOrderLineRepository orderLineRepository)
    {
      _unitOfWork = unitOfWork;
      _orderRepository = orderRepository;
      _orderLineRepository = orderLineRepository;
    }

    public async Task SaveOrder(Order order)
    {
      _orderRepository.Add(order);

      foreach (var item in order.OrderLineItems)
      {
        await _orderLineRepository.AddAsync(item);
      }

      await _unitOfWork.SaveChangesAsync();

    }

    public async Task<ICollection<Order>?> GetOrdersByUserId(Guid id)
    {
      return await _orderRepository.GetOrdersByUserId(id);
    }

    public async Task DeleteOrder(Guid orderId)
    {
      var order = await _orderRepository.GetAsync(orderId) ?? throw new Exception("Order not found");

      _orderRepository.Delete(order);
      await _unitOfWork.SaveChangesAsync();
    }

    public async Task<ICollection<Order>?> GetAllOrderAsync()
    {
      return await _orderRepository.GetAllOrderIncludeItemsAsync();
    }
  }


}

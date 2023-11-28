using AutoMapper;
using basitsatinalimuyg.Behaviors;
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
    private readonly IMapper _mapper;

    public OrderService(IMapper mapper, IUnitOfWork unitOfWork, IOrderRepository orderRepository, IOrderLineRepository orderLineRepository)
    {
      _unitOfWork = unitOfWork;
      _orderRepository = orderRepository;
      _orderLineRepository = orderLineRepository;
      _mapper = mapper;
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
  }


}

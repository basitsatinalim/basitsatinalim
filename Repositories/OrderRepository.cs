using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Context;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace basitsatinalimuyg.Repositories
{
  public class OrderRepository : BaseRepository<Order>, IOrderRepository
  {
    private readonly AppDbContext _appDbContext;

    public OrderRepository(AppDbContext appDbContext) : base(appDbContext)
    {
      _appDbContext = appDbContext;
    }

    public async Task<ICollection<Order>?> GetOrdersByUserId(Guid id)
    {
      return await _appDbContext.Orders.Include(x => x.OrderLineItems).Where(x => x.UserId == id).ToListAsync();
    }

  }
}



using basitsatinalimuyg.Context;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Repositories.Abstraction;

namespace basitsatinalimuyg.Repositories
{
  public class OrderLineRepository : BaseRepository<OrderLineItem>, IOrderLineRepository
  {

    private readonly AppDbContext _context;

    public OrderLineRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }



  }
}
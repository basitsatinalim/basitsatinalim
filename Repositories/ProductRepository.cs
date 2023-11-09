using basitsatinalimuyg.Context;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Repositories.Abstraction;

namespace basitsatinalimuyg.Repositories
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		private readonly AppDbContext _appDbContext;
		public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
		{
			_appDbContext = appDbContext;
		}
	}
}

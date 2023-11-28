using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Context;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace basitsatinalimuyg.Repositories
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		private readonly AppDbContext _appDbContext;

		public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<ICollection<Product>> GetAllProductsByCreatedAt()
		{
			return await _appDbContext.Products.OrderByDescending(x => x.CreatedAt).Take(8).ToListAsync();
		}

		public async Task<ICollection<Product>> GetFilteredProductsAsync(CategoryEnum? category)
		{
			return await _appDbContext.Products.Where(x => x.Category == category).ToListAsync();
		}

		public async Task<ICollection<Product>> GetSearchedProducts(string? search)
		{
			var products = await _appDbContext.Products.Where(x => x.Name!.ToLower().Contains(search!.ToLower())).ToListAsync();
			return products;
		}
	}
}

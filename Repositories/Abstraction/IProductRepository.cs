using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Entities;

namespace basitsatinalimuyg.Repositories.Abstraction
{
	public interface IProductRepository : IRepository<Product>
	{
		Task<ICollection<Product>> GetAllProductsByCreatedAt();
		Task<ICollection<Product>> GetFilteredProductsAsync(CategoryEnum? category);
		Task<ICollection<Product>> GetSearchedProducts(string? search);
	}
}

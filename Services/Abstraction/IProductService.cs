using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Entities;

namespace basitsatinalimuyg.Services.Abstraction
{
	public interface IProductService
	{

		Task<ICollection<Product?>> GetAllProducts();
		Task<Product?> GetProductById(Guid id);
		Task<Product?> CreateProduct(ProductDto newProduct);
		Task UpdateProduct(ProductDto product);
		Task DeleteProduct(Product product);

	}
}

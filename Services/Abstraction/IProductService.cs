using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Models;

namespace basitsatinalimuyg.Services.Abstraction
{
	public interface IProductService
	{

		Task<ICollection<ProductViewModel>> GetAllProducts();
		Task<ICollection<ProductViewModel>> GetFilteredProducts(CategoryEnum? category);
		Task<ICollection<ProductViewModel>> GetSearchedProducts(string? search);
		Task<ICollection<ProductViewModel>> GetAllProductsByCreatedAt();
		Task<ProductViewModel> GetProductById(Guid id);
		Task<ProductViewModel> CreateProduct(ProductDto newProduct);
		Task UpdateProduct(ProductDto product);
		Task DeleteProduct(Guid id);
		Task<Product?> GetProductByIdAsEntity(Guid guid);
	}
}

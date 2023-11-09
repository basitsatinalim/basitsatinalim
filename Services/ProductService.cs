using AutoMapper;
using basitsatinalimuyg.Behaviors;
using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Repositories.Abstraction;
using basitsatinalimuyg.Services.Abstraction;

namespace basitsatinalimuyg.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> CreateProduct(ProductDto newProduct)
        {
            var response = _mapper.Map<Product>(newProduct);

            var product =  await _productRepository.AddAsync(response);

            await _unitOfWork.SaveChangesAsync();

            return product;

        }

        public Task DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Product>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();

            
            return products;
        }

        public Task<Product> GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(ProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}

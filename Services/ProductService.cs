using AutoMapper;
using basitsatinalimuyg.Behaviors;
using basitsatinalimuyg.Config;
using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Models;
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

        public async Task<ProductViewModel> CreateProduct(ProductDto newProduct)
        {
            var productEntity = _mapper.Map<Product>(newProduct);

            var product = await _productRepository.AddAsync(productEntity);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductViewModel>(product);

        }

        public async Task DeleteProduct(Guid id)
        {
            var product = await _productRepository.GetAsync(id) ?? throw new Exception("Product not found");

            _productRepository.Delete(product);

            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<ICollection<ProductViewModel>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();


            return _mapper.CastListObject<ProductViewModel, ICollection<Product?>>(products);
        }

        public async Task<ICollection<ProductViewModel>> GetFilteredProducts(CategoryEnum? category)
        {

            var products = await _productRepository.GetFilteredProductsAsync(category);


            return _mapper.CastListObject<ProductViewModel, ICollection<Product>>(products);
        }

        public async Task<ICollection<ProductViewModel>> GetSearchedProducts(string? search)
        {
            var products = await _productRepository.GetSearchedProducts(search);


            return _mapper.CastListObject<ProductViewModel, ICollection<Product>>(products);
        }


        public async Task<ProductViewModel> GetProductById(Guid id)
        {
            var product = await _productRepository.GetAsync(id);

            return _mapper.Map<ProductViewModel>(product);
        }

        public Task UpdateProduct(ProductDto product)
        {

            var productEntity = _mapper.Map<Product>(product);

            _productRepository.Update(productEntity);

            return _unitOfWork.SaveChangesAsync();

        }

        public async Task<ICollection<ProductViewModel>> GetAllProductsByCreatedAt()
        {
            var products = await _productRepository.GetAllProductsByCreatedAt();

            return _mapper.CastListObject<ProductViewModel, ICollection<Product>>(products);
        }

        public async Task<Product?> GetProductByIdAsEntity(Guid guid)
        {
            return await _productRepository.GetAsync(guid);
        }
    }
}

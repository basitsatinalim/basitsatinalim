using Microsoft.AspNetCore.Mvc;
using basitsatinalimuyg.Services.Abstraction;
using basitsatinalimuyg.Constants;

namespace basitsatinalimuyg.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index([FromQuery(Name = "category")] CategoryEnum? category, [FromQuery(Name = "search")] string? search)
        {


            if (category != null)
            {
                var filtredProducts = await _productService.GetFilteredProducts(category);

                return View(filtredProducts);
            }
            if (search != null)
            {
                var filtredProducts = await _productService.GetSearchedProducts(search);

                return View(filtredProducts);
            }

            var products = await _productService.GetAllProducts();

            return View(products);

        }

        public async Task<IActionResult> Details(Guid? id)
        {
            var productId = id?.ToString();
            if (productId == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductById(Guid.Parse(productId));

            return View(product);
        }

        [HttpGet]
        [ActionName("JsonDetails")]
        public async Task<IActionResult> JsonDetails(Guid? id)
        {

            var productId = id?.ToString();
            if (productId == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductById(Guid.Parse(productId));

            return Ok(product);
        }
    }
}

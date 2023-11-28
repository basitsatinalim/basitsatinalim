using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using basitsatinalimuyg.Context;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Services.Abstraction;
using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Dtos;
using Microsoft.AspNetCore.Authorization;

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
        //create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Amount,Currency,ImageUrl,Category,Stock")] ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var productEntity = await _productService.CreateProduct(product);

                if (productEntity == null)
                {
                    return Problem("Product entity could not created.");
                }
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        [HttpGet]
        [Authorize(Roles = $"{UserRoles.ROLE_ADMIN}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            var productId = id?.ToString();
            if (productId == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductById(Guid.Parse(productId));

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{UserRoles.ROLE_ADMIN}")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,Amount,Currency,ImageUrl,Category,Stock")] ProductDto product)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateProduct(product);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        [HttpGet]
        [Authorize(Roles = $"{UserRoles.ROLE_ADMIN}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var productId = id?.ToString();
            if (productId == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductById(Guid.Parse(productId));

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"{UserRoles.ROLE_ADMIN}")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _productService.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

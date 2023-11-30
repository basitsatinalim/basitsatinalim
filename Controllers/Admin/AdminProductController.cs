using Microsoft.AspNetCore.Mvc;
using basitsatinalimuyg.Services.Abstraction;
using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Dtos;
using Microsoft.AspNetCore.Authorization;
using basitsatinalimuyg.Repositories.Abstraction;
using AutoMapper;

namespace basitsatinalimuyg.Controllers
{
  [Route("Admin/Product")]
  [Authorize(Roles = $"{UserRoles.ROLE_ADMIN}")]
  public class AdminProductController : Controller
  {
    private readonly IProductRepository _productRepository;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public AdminProductController(IProductRepository productRepository, IMapper mapper, IProductService productService)
    {
      _productRepository = productRepository;
      _mapper = mapper;
      _productService = productService;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
      var products = await _productRepository.GetAllAsync();
      return View("Product/Index", products);
    }

    [HttpGet("Details/{id}")]
    public IActionResult Details(Guid? id)
    {
      return RedirectToAction("Details", "Product", id);
    }

    [HttpGet]
    [Route("Create")]
    //create
    public IActionResult Create()
    {
      return View("Product/Create");
    }

    [HttpPost]
    [Route("Create")]
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

      return View("Product/Create", product);
    }

    [HttpGet("Edit/{id}")]
    [Authorize(Roles = $"{UserRoles.ROLE_ADMIN}")]
    public async Task<IActionResult> Edit(Guid? id)
    {
      var productId = id?.ToString();
      if (productId == null)
      {
        return NotFound();
      }

      var product = _mapper.Map<ProductDto>(await _productRepository.GetAsync(Guid.Parse(productId)));

      return View("Product/Edit", product);
    }

    [HttpPost("Edit/{id}")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = $"{UserRoles.ROLE_ADMIN}")]
    public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,Amount,Currency,ImageUrl,Category,Stock")] ProductDto product)
    {
      if (ModelState.IsValid)
      {
        var productEntity = await _productRepository.GetAsync(id);
        if (productEntity == null)
        {
          return NotFound();
        }

        await _productService.UpdateProduct(id, product);

        return RedirectToAction(nameof(Index));
      }
      return View("Product/Edit", product);
    }

    [HttpGet]
    [Route("Delete/{id}")]
    [Authorize(Roles = $"{UserRoles.ROLE_ADMIN}")]
    public async Task<IActionResult> Delete(Guid? id)
    {
      var productId = id?.ToString();
      if (productId == null)
      {
        return NotFound();
      }

      await _productService.DeleteProduct(Guid.Parse(productId));

      return RedirectToAction(nameof(Index));
    }
  }
}

using basitsatinalimuyg.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace basitsatinalimuyg.Controllers
{
	public class CartController : Controller
	{

		private	readonly IProductService _productService;
		private readonly IUserService _userService;

		public CartController(IProductService productService, IUserService userService)
		{
			_productService = productService;
			_userService = userService;
		}



		public IActionResult Index()
		{
			return View();
		}


		public IActionResult AddToCart(int id)
		{
			return View();
		}

		public IActionResult RemoveFromCart(int id)
		{
			return View();
		}

		public IActionResult ClearCart()
		{
			return View();
		}

	}
}

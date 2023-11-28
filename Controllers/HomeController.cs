using basitsatinalimuyg.Models;
using basitsatinalimuyg.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace basitsatinalimuyg.Controllers
{
    public class HomeController : Controller
    {


		private readonly IProductService _productService;

		public HomeController(IProductService productService)
		{
			_productService = productService;
		}


        public async Task<IActionResult> Index()
        {
			var products = await _productService.GetAllProductsByCreatedAt();
			return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		[HttpGet]
		public IActionResult GetCustomCookie(string title, string returnUrl)
		{
			ViewData[title] = Request.Cookies["CustomCookie"];

			return Redirect(returnUrl);
		}

		[HttpGet]
		public IActionResult SetCustomCookie(string title, string data, string returnUrl)
		{
			var cookieOptions = new CookieOptions
			{
				Expires = DateTime.Now.AddDays(30),
				IsEssential = true
			};
			Response.Cookies.Append(title, data, cookieOptions);

			return Redirect(returnUrl);
		}


		[HttpGet]
		public IActionResult DeleteCustomCookie(string title, string returnUrl)
		{
			var cookieOptions = new CookieOptions
			{
				Expires = DateTime.Now.AddDays(-1)
			};

			Response.Cookies.Append(title, "", cookieOptions);

			return Redirect(returnUrl);
		}
	}
}
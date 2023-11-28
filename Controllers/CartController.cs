using basitsatinalimuyg.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace basitsatinalimuyg.Controllers
{
	public class CartController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}

	}
}

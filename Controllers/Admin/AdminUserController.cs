
using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Repositories.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace basitsatinalimuyg.Controllers
{
	[Route("Admin/User")]
	[Route("Admin/User/{action}")]
	[Authorize(Roles = $"{UserRoles.ROLE_ADMIN}")]
	public class AdminUserController : Controller
	{

		private readonly IUserRepository _userRepository;

		public AdminUserController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}


		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet("{id}")]
		public IActionResult Detail(Guid id)
		{
			return View();
		}

		[HttpGet("Create")]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost("Create")]

		public IActionResult Create(object model)
		{
			return View();
		}

		[HttpGet("Edit/{id}")]

		public IActionResult Edit(int id)
		{
			return View();
		}

		[HttpPost("Edit/{id}")]

		public IActionResult Edit(int id, object model)
		{
			return View();
		}

		[HttpGet("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			return View();
		}

		[HttpPost("Delete/{id}")]

		public IActionResult Delete(int id, object model)
		{
			return View();
		}

		[HttpGet("ChangePassword/{id}")]

		public IActionResult ChangePassword(int id)
		{
			return View();
		}

		[HttpPost("ChangePassword/{id}")]

		public IActionResult ChangePassword(int id, object model)
		{
			return View();
		}

		[HttpGet("ChangeEmail/{id}")]

		public IActionResult ChangeEmail(int id)
		{
			return View();
		}

		[HttpPost("ChangeEmail/{id}")]

		public IActionResult ChangeEmail(int id, object model)
		{
			return View();
		}

		[HttpGet("ChangeUsername/{id}")]

		public IActionResult ChangeUsername(int id)
		{
			return View();
		}

		[HttpPost("ChangeUsername/{id}")]

		public IActionResult ChangeUsername(int id, object model)
		{
			return View();
		}

		[HttpGet("ChangeRole/{id}")]

		public IActionResult ChangeRole(int id)
		{
			return View();
		}

		[HttpPost("ChangeRole/{id}")]

		public IActionResult ChangeRole(int id, object model)
		{
			return View();
		}

		[HttpGet("ChangeStatus/{id}")]

		public IActionResult ChangeStatus(int id)
		{
			return View();
		}

		[HttpPost("ChangeStatus/{id}")]

		public IActionResult ChangeStatus(int id, object model)
		{
			return View();
		}

		[HttpGet("ChangeProfilePhoto/{id}")]

		public IActionResult ChangeProfilePhoto(int id)
		{
			return View();
		}

		[HttpPost("ChangeProfilePhoto/{id}")]

		public IActionResult ChangeProfilePhoto(int id, object model)
		{
			return View();
		}

	}
}

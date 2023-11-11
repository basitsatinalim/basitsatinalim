using AutoMapper;
using basitsatinalimuyg.Config;
using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Models;
using basitsatinalimuyg.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace basitsatinalimuyg.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		private readonly IMapper _mapper;

		public UserController(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		[HttpGet]
		[Authorize(Roles = $"{UserRoles.ROLE_USER}")]
		public async Task<IActionResult> Index()
		{

			var users = await _userService.GetAllUsers();

			return View(_mapper.CastListObject<UserViewModel, ICollection<User?>>(users));
		}

	}
}

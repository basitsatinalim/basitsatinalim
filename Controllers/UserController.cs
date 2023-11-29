using AutoMapper;
using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Models;
using basitsatinalimuyg.Services.Abstraction;
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
		public async Task<IActionResult> Details(Guid id)
		{
			var user = await _userService.GetUserById(id);

			if (user == null)
			{
				return NotFound();
			}

			return View(_mapper.Map<UserViewModel>(user));
		}

		[HttpPost]
		public async Task<IActionResult> Update(UserDto userDto)
		{
			var user = await _userService.GetUserByEmailAsEntity(userDto.Email);

			if (user == null)
			{
				return NotFound();
			}

			user.Name = userDto.Name ?? user.Name;
			user.Surname = userDto.Surname ?? user.Surname;
			user.Email = userDto.Email ?? user.Email;
			user.Phone = userDto.Phone ?? user.Phone;
			user.ImageUrl = userDto.ImageUrl ?? user.ImageUrl;
			user.Gender = userDto.Gender;
			user.BirthDate = userDto.BirthDate ?? user.BirthDate;
			user.UpdatedAt = DateTime.Now;

			await _userService.UpdateUser(user);

			return RedirectToAction("Index", "Profile");
		}

	}
}

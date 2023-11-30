
using AutoMapper;
using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Context;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Repositories.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace basitsatinalimuyg.Controllers
{
	[Authorize(Roles = $"{UserRoles.ROLE_ADMIN}")]
	[Route("Admin/User")]
	public class AdminUserController : Controller
	{
		private readonly IUserRepository _userRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public AdminUserController(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_userRepository = userRepository;
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}


		[HttpGet]
		public async Task<IActionResult> Index()
		{

			var allUsers = await _userRepository.GetAllAsync();

			return View("User/Index", allUsers);
		}

		[HttpGet]
		[Route("Edit/{id}")]
		public async Task<IActionResult> Edit(Guid id)
		{

			var user = await _userRepository.GetAsync(id);
			return View("User/Edit", user);
		}

		[HttpPost]
		[Route("Edit/{id}")]
		public async Task<IActionResult> Edit(Guid id, User user)
		{
			var dbUser = await _userRepository.GetAsync(id) ?? throw new NullReferenceException();

			dbUser.Email = user.Email;
			dbUser.Name = user.Name;
			dbUser.Surname = user.Surname;
			dbUser.Role = user.Role;
			dbUser.ImageUrl = user.ImageUrl;
			dbUser.BirthDate = user.BirthDate;
			dbUser.Phone = user.Phone;
			dbUser.Gender = user.Gender;
			dbUser.UpdatedAt = DateTime.Now;

			_userRepository.Update(dbUser);
			await _unitOfWork.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		[HttpPost("Delete/{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var dbUser = await _userRepository.GetAsync(id) ?? throw new NullReferenceException();
			_userRepository.Delete(dbUser);
			await _unitOfWork.SaveChangesAsync();
			return RedirectToAction("Index");
		}

	}
}

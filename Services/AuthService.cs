using AutoMapper;
using basitsatinalimuyg.Behaviors;
using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Repositories.Abstraction;
using basitsatinalimuyg.Services.Abstraction;
using basitsatinalimuyg.Utils.Abstraction;

namespace basitsatinalimuyg.Services
{
	public class AuthService : IAuthService
	{
		private readonly IUserService _userService;
		private readonly IUserRepository _userRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IHasher _hasher;

		public AuthService(IUserService userService, IMapper mapper, IUnitOfWork unitOfWork, IHasher hasher, IUserRepository userRepository)
		{
			_userService = userService;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_hasher = hasher;
			_userRepository = userRepository;
		}

		public async Task<User?> Register(RegisterDto register)
		{

			if (await IsEmailExist(register.Email!)) return null;

			register.Password = _hasher.Hash(register.Password!);

			var user = _mapper.Map<User>(register);

			return await _userService.CreateUser(user);
		}

		public async Task<User?> Login(string email, string password)
		{

			var user = await _userRepository.GetUserByEmail(email);

			if (user == null) return null;

			if (user.Password != _hasher.Hash(password)) return null;

			return user;

		}

		private async Task<bool> IsEmailExist(string email) {
			return await _userService.GetUserByEmail(email) != null;
		}
	}
}

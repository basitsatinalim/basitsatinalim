using basitsatinalimuyg.Behaviors;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Repositories.Abstraction;
using basitsatinalimuyg.Services.Abstraction;

namespace basitsatinalimuyg.Services
{
	public class UserService : IUserService
	{

		private readonly IUserRepository _userRepository;
		private readonly IUnitOfWork _unitOfWork;


		public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
		{
			_userRepository = userRepository;
			_unitOfWork = unitOfWork;
		}


		public async Task<User?> CreateUser(User user)
		{
			if (user == null) return null;
			var savedUser = await _userRepository.AddAsync(user);
			await _unitOfWork.SaveChangesAsync();
			return savedUser;
		}

		public Task DeleteUser(User user)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<User?>> GetAllUsers()
		{
			throw new NotImplementedException();
		}

		public async Task<User?> GetUserByEmail(string? email)
		{
			return await _userRepository.GetUserByEmail(email);
		}

		public Task<User?> GetUserById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateUser(User user)
		{
			throw new NotImplementedException();
		}
	}
}

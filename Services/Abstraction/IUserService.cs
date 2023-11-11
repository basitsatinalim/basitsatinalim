using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Entities;

namespace basitsatinalimuyg.Services.Abstraction
{
	public interface IUserService
	{
		Task<ICollection<User?>> GetAllUsers();
		Task<User?> GetUserById(Guid id);
		Task<User?> CreateUser(User user);
		Task UpdateUser(User user);
		Task DeleteUser(User user);
		Task<User?> GetUserByEmail(string? email);
	}
}

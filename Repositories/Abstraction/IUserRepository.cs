using basitsatinalimuyg.Entities;

namespace basitsatinalimuyg.Repositories.Abstraction
{
	public interface IUserRepository : IRepository<User>
	{
		Task<User?> GetUserByEmail(string? email);
	}
}

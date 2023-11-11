using basitsatinalimuyg.Dtos;
using basitsatinalimuyg.Entities;

namespace basitsatinalimuyg.Services.Abstraction
{
	public interface IAuthService
	{
		Task<User?> Register(RegisterDto register);
		Task<User?> Login(string email, string password);
	}
}

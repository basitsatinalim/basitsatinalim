using basitsatinalimuyg.Context;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace basitsatinalimuyg.Repositories
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		private readonly AppDbContext _appDbContext;
		public UserRepository(AppDbContext appDbContext) : base(appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<User?> GetUserByEmail(string? email)
		{
			return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
		}
	}
}

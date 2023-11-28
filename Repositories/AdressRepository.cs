using basitsatinalimuyg.Context;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace basitsatinalimuyg.Repositories
{
    public class AdressRepository : BaseRepository<Address>, IAdressRepository
    {
        private readonly AppDbContext _appDbContext;
        public AdressRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ICollection<Address>> GetAllAsync(Guid id)
        {
			return await _appDbContext.Addresses.Where(x => x.UserId == id).ToListAsync();
		}
    }
}

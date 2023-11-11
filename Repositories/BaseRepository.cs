using basitsatinalimuyg.Context;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace basitsatinalimuyg.Repositories
{
	public class BaseRepository<T> : IRepository<T> where T : BaseEntity

	{
		private readonly AppDbContext _appDbContext;

		public BaseRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<T?> AddAsync(T entity)
		{
			await _appDbContext.Set<T>().AddAsync(entity);
			return entity;
		}

		public T? Delete(T entity)
		{
			_appDbContext.Set<T>().Remove(entity);
			return entity;
		}

		public async Task<T?> GetAsync(T entity)
		{
			return await _appDbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id);
		}

		public async Task<T[]> GetAllAsync()
		{
			var result = await _appDbContext.Set<T>().ToArrayAsync();
			return result;
		}

		public T? Update(T entity)
		{
			_appDbContext.Set<T>().Update(entity);
			return entity;
		}

		public T? Add(T entity)
		{
			_appDbContext.Set<T>().Add(entity);
			return entity;
		}
	}
}

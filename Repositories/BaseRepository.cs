using basitsatinalimuyg.Context;
using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Entities.Abstraction;
using basitsatinalimuyg.Repositories.Abstraction;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace basitsatinalimuyg.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity

	{
		private readonly AppDbContext _appDbContext;

		public BaseRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<T?> AddAsync(T entity)
		{
			await _appDbContext.Set<T>().AddAsync(entity);
			await _appDbContext.SaveChangesAsync();
			return entity;
		}

		public async Task<T?> DeleteAsync(T entity)
		{
			_appDbContext.Set<T>().Remove(entity);
			await _appDbContext.SaveChangesAsync();
			return entity;
		}

		public async Task<T?> GetAsync(T entity)
		{
			return await _appDbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id);
		}

		public async Task<T[]> GetAllAsync()
		{
			var result = await _appDbContext.Set<T>().ToArrayAsync();
			await _appDbContext.SaveChangesAsync();
			return result;
		}

		public T? Update(T entity)
		{
			_appDbContext.Set<T>().Update(entity);
			_appDbContext.SaveChanges();
			return entity;
		}

		public T? Add(T entity)
		{
			_appDbContext.Set<T>().Add(entity);
			_appDbContext.SaveChanges();
			return entity;
		}
	}
}

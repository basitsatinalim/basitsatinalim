using basitsatinalimuyg.Entities;
using basitsatinalimuyg.Entities.Abstraction;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace basitsatinalimuyg.Repositories.Abstraction
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		public T? Add(T entity);
		public Task<T?> GetAsync(T entity);
		public Task<T[]> GetAllAsync();
		public Task<T?> AddAsync(T entity);
		public T? Update(T entity);
		public Task<T?> DeleteAsync(T entity);
	}
}

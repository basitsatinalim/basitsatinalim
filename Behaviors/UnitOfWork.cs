using basitsatinalimuyg.Context;

namespace basitsatinalimuyg.Behaviors
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _dbContext;
		public UnitOfWork(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<int> SaveChangesAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}
		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
		{
			return await _dbContext.SaveChangesAsync(cancellationToken);
		}

	}
}

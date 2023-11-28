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
			using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				var result = await _dbContext.SaveChangesAsync();
				transaction.Commit();
				return result;
			}
			catch
			{
				transaction.Rollback();
				return 0;
			}
		}
		public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
		{

			using var transaction = _dbContext.Database.BeginTransaction();
			try
			{
				var result = await _dbContext.SaveChangesAsync(cancellationToken);
				transaction.Commit();
				return result;
			}
			catch
			{
				transaction.Rollback();
				return 0;
			}
		}

	}
}

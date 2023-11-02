namespace basitsatinalimuyg.Behaviors
{
	public interface IUnitOfWork
	{
		Task<int> SaveChangesAsync();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}

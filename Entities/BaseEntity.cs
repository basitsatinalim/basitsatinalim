using basitsatinalimuyg.Entities.Abstraction;

namespace basitsatinalimuyg.Entities
{
	public class BaseEntity : IEntity
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime UpdatedAt { get; set; } = DateTime.Now;
	}
}

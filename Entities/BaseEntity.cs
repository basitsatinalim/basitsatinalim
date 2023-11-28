using System.ComponentModel.DataAnnotations;
using basitsatinalimuyg.Entities.Abstraction;

namespace basitsatinalimuyg.Entities
{
	public class BaseEntity : IEntity
	{
		public Guid Id { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime UpdatedAt { get; set; } = DateTime.Now;
		[ConcurrencyCheck]
		public Guid? Version { get; set; }
	}
}

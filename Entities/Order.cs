using basitsatinalimuyg.Entities.Abstraction;
using basitsatinalimuyg.Entities.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace basitsatinalimuyg.Entities
{
	public sealed class Order : BaseEntity
	{
		public User User { get; set; } = null!;
		public Guid UserId { get; set; }
		public ICollection<OrderLineItem>? Orders { get; set; }
		public OrderStatusEnum? Status { get; set; }
		public double Total { get; set; }
		[DataType(DataType.Date)]
		public DateTime? Date { get; set; }
		public string? Note { get; set; }

	}


}

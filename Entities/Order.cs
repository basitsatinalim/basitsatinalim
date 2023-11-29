using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Entities.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace basitsatinalimuyg.Entities
{
	public sealed class Order : BaseEntity
	{
		public User User { get; set; } = null!;
		public Guid UserId { get; set; }
		public ICollection<OrderLineItem> OrderLineItems { get; set; } = new List<OrderLineItem>();
		public OrderStatusEnum? Status { get; set; }
		public Money? Total { get; set; }
		public Guid? ShippingAddressId { get; set; }
		public Payment? Payment { get; set; }
		[DataType(DataType.Date)]
		public DateTime? Date { get; set; } = DateTime.Now;

	}


}

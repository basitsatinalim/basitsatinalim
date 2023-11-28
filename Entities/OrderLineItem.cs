using basitsatinalimuyg.Constants;

namespace basitsatinalimuyg.Entities
{
    public class OrderLineItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public Product Product { get; set; } = null!;
        public Order Order { get; set; } = null!;
        public int Count { get; set; }
        public Money? Price { get; set; }
        public CategoryEnum? Category { get; set; }
    }
}

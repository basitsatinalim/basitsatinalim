namespace basitsatinalimuyg.Entities
{
    public class OrderLineItem : BaseEntity
    {

        public Product Product { get; set; } = null!;
        public Guid ProductId { get; set; }
        public Order Order { get; set; } = null!;
        public Guid OrderId { get; set; }

    }
}

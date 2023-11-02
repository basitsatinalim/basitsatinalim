namespace basitsatinalimuyg.Entities
{
    public class OrderLineItem
    {

        public Guid Id { get; set; }
        public Product Product { get; set; } = null!;
        public Guid ProductId { get; set; }
        public Order Order { get; set; } = null!;
        public Guid OrderId { get; set; }
        public OrderLineItem()
        {
            Id = Guid.NewGuid();
        }

    }
}

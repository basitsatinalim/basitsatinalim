namespace basitsatinalimuyg.Models
{
	public class CartViewModel
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int UserId { get; set; }
		public int Quantity { get; set; }
		public decimal TotalPrice { get; set; }
		public ProductViewModel Product { get; set; }
		public UserViewModel User { get; set; }
	}
}

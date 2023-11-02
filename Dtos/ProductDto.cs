using basitsatinalimuyg.Entities.Constants;
using basitsatinalimuyg.Entities;

namespace basitsatinalimuyg.Dtos
{
	public class ProductDto
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
		public decimal? Amount { get; set; }
		public CurrencyEnum? Currency { get; set; }
		public string? ImageUrl { get; set; }
		public CategoryEnum? Category { get; set; }
		public int? Stock { get; set; }
	}
}

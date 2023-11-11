using basitsatinalimuyg.Constants;
using System.ComponentModel.DataAnnotations;

namespace basitsatinalimuyg.Dtos
{
    public class ProductDto
	{
		[Required]
		[MinLength(3)]
		[MaxLength(50)]
		public string? Name { get; set; }
		[Required]
		public string? Description { get; set; }
		[Required]
		public decimal? Amount { get; set; }
		[Required]
		public CurrencyEnum? Currency { get; set; }
		[Required]
		public string? ImageUrl { get; set; }
		[Required]
		public CategoryEnum? Category { get; set; }
		[Required]
		public int? Stock { get; set; }
	}
}

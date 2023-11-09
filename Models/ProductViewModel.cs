using basitsatinalimuyg.Entities.Constants;
using basitsatinalimuyg.Entities;

namespace basitsatinalimuyg.Models
{
	public class ProductViewModel: BaseViewModel
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
		public Money? Price { get; set; }
		public string? ImageUrl { get; set; }
		public CategoryEnum? Category { get; set; }
		public int? Stock { get; set; }
	}
}

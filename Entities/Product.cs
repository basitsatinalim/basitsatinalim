﻿using basitsatinalimuyg.Entities.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace basitsatinalimuyg.Entities
{
	[Table("products")]
	public sealed class Product : BaseEntity
	{
		public string? Name { get; set; }
		public string? Description { get; set; }
		public Money? Price { get; set; }
		public string? ImageUrl { get; set; }
		public CategoryEnum? Category { get; set; }
		public int? Stock { get; set; }

	}

}

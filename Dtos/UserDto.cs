

using System.ComponentModel.DataAnnotations;

namespace basitsatinalimuyg.Dtos
{
	public class UserDto
	{
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? Phone { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public string? Country { get; set; }
		public string? PostalCode { get; set; }
		public string? ImageUrl { get; set; }
		public DateTime? BirthDay { get; set; }
	}
}

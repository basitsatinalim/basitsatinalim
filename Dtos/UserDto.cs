

using System.ComponentModel.DataAnnotations;
using basitsatinalimuyg.Constants;

namespace basitsatinalimuyg.Dtos
{
	public class UserDto
	{
		public Guid? Id { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public string? ImageUrl { get; set; }
		public bool Gender { get; set; }
		public DateTime? BirthDate { get; set; }
	}
}

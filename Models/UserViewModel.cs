

using basitsatinalimuyg.Constants;
using basitsatinalimuyg.Entities;

namespace basitsatinalimuyg.Models
{
	public class UserViewModel : BaseViewModel
	{
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public string? ImageUrl { get; set; }
		public bool Gender { get; set; }
		public UserRoleEnum Role { get; set; }
		public DateTime? BirthDate { get; set; }
	}
}
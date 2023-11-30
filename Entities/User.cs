
using basitsatinalimuyg.Constants;
using NuGet.Protocol.Plugins;

namespace basitsatinalimuyg.Entities
{
	public sealed class User : BaseEntity
	{
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set; }
		public bool Gender { get; set; }
		public string? Phone { get; set; }
		public ICollection<Address>? Addresses { get; set; }
		public UserRoleEnum Role { get; set; } = UserRoleEnum.ROLE_USER;
		public string? ImageUrl { get; set; }
		public DateTime? BirthDate { get; set; }
		public ICollection<Order> Orders { get; } = new List<Order>();


		public string FullName => $"{Name} {Surname}";
	}
}

using System.ComponentModel.DataAnnotations;

namespace basitsatinalimuyg.Dtos
{
	public class RegisterDto
	{
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Surname { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		[EmailAddress]
		[MinLength(8)]
		[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
		public string? Email { get; set; }
		[Required]
		public bool Gender { get; set; }
		[Required]
		[MinLength(6)]
		[MaxLength(50)]
		[DataType(DataType.Password)]
		public string? Password { get; set; }
		[Required]
		[MinLength(6)]
		[MaxLength(50)]
		[DataType(DataType.Password)]
		[Compare("Password")]
		public string? ConfirmPassword { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime? BirthDate { get; set; }
	}
}

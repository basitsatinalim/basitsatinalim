using System.ComponentModel.DataAnnotations;

namespace basitsatinalimuyg.Dtos
{
	public class LoginDto
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		[MinLength(8)]
		[MaxLength(50)]
		[DataType(DataType.EmailAddress)]
		[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Invalid Email Address")]
		public string? Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		[MinLength(6)]
		public string? Password { get; set; }
		public bool RememberMe { get; set; }
	}


}

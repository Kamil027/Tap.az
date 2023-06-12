using System.ComponentModel.DataAnnotations;

namespace tap.az.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[StringLength(maximumLength: 25)]
		public string Username { get; set; }
		[Required]
		[StringLength(maximumLength: 25)]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[StringLength(maximumLength: 25, MinimumLength = 8)]
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }
	}
}

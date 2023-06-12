using Microsoft.AspNetCore.Identity;
namespace tap.az.Models
{
	public class AppUser : IdentityUser
	{
		public List<Elan>? Elans { get; set; }
	}
}

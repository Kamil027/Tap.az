using System.ComponentModel.DataAnnotations;

namespace tap.az.Models.Kataqoriler
{
	public class Category
	{
		public int Id { get; set; }
		[Required]
		[StringLength(maximumLength: 45)]
		public string Name { get; set; }
		public List<SecondCategory>? secondCategories { get; set;}
	}
}

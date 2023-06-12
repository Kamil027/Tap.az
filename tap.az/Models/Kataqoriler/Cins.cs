using System.ComponentModel.DataAnnotations;

namespace tap.az.Models.Kataqoriler
{
	public class Cins
	{
		public int Id { get; set; }
		public int SecondCategoryId { get; set; }
		[Required]
		[StringLength(maximumLength: 45)]
		public string Name { get; set; }
		public SecondCategory? SecondCategory { get; set; }
		public List<Elan>? Elans { get; set; }
	}
}

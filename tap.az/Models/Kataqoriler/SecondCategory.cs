using System.ComponentModel.DataAnnotations;

namespace tap.az.Models.Kataqoriler
{
	public class SecondCategory
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		[Required]
		[StringLength(maximumLength: 45)]
		public string Name { get; set; }
		public Category? Category { get; set; }	
		public List<Marka>? Markas { get; set; }
		public List<Cins>? Cins { get; set; }
		public List<MalinNovu>? MalinNovu { get; set; }

	}
}

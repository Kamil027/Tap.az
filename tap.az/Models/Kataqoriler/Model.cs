using System.ComponentModel.DataAnnotations;

namespace tap.az.Models.Kataqoriler
{
	public class Model
	{
		public int Id { get; set; }
		public int MarkaId { get; set; }
		[Required]
		[StringLength(maximumLength: 45)]
		public string Name { get; set; }
		public Marka? Marka { get; set; }
		public List<Elan>? Elans { get; set; }

	}
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tap.az.Models.Kataqoriler;

namespace tap.az.Models
{
	public class Elan
	{

		public int Id { get; set; }

		public int CityId { get; set; }
		public int? ModelId { get; set; }
		public int? MalinNovuId { get; set; }
		public int? CinsId { get; set; }

		[Required]
		public string AppUserId { get; set; }
		[Required]
		[StringLength(maximumLength: 30)]
		public string ElanName { get; set; }
		[Required]
		[StringLength(maximumLength: 30)]
		public double Price { get; set; }
		[Required]
		[StringLength(maximumLength: 300)]
		public string? Description { get; set; }
		[Required]
		[StringLength(maximumLength: 30)]
		public string Name { get; set; }
		[Required]
		[StringLength(maximumLength: 30)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[StringLength(maximumLength: 10)]
		public string Phone { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime Date { get; set; }
		public int? IsNew { get; set; }
		public int? IsDelivery { get; set; }
		public string? ImageUrl { get; set; }
		public AppUser? AppUser { get; set; }
		public City? City { get; set; }
		public Model? Model { get; set; }
		public MalinNovu? MalinNovu { get;set; }
		public Cins? Cins { get; set; }


		[NotMapped]
		public IFormFile? ImageFile { get; set; }
	}
}

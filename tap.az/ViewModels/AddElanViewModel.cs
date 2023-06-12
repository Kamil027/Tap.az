using System.ComponentModel.DataAnnotations;

namespace tap.az.ViewModels
{
	public class AddElanViewModel
	{
		
		public int? Id { get; set; }
		[Required]
		public int AddFirstCategoryId { get; set; }
		public int AddSecondCategoryId { get; set; }
		public int AddThirdCategoryId { get; set; }
		public int? AddFourthCategoryId { get; set; }
		[Required]
		public int AddCityId { get; set; }
		[Required]
		public int AddPrice { get; set; }
		[Required]
		[StringLength(maximumLength: 30)]
		public string AddElanName { get; set; }
		[Required]
		[StringLength(maximumLength: 300)]
		public string AddDescription { get; set; }
		[Required]
		[StringLength(maximumLength: 30)]
		public string AddPersonName { get; set; }
		[Required]
		[StringLength(maximumLength: 30)]
		[DataType(DataType.EmailAddress)]
		public string AddEmail { get; set; }
		[Required]
		[StringLength(maximumLength: 10)]
		public string AddPhoneNumber { get; set; }
		public string? AddImageUrl { get; set; }
		public bool AddIsNew { get; set; }
		public bool AddIsDeliver { get; set; }

		public IFormFile? AddImageFile { get; set; }
	}
}

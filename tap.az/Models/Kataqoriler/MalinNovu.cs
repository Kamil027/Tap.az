namespace tap.az.Models.Kataqoriler
{
	public class MalinNovu
	{
		public int Id { get; set; }
		public int SecondCategoryId { get; set; }
		public string Name { get; set; }
		public SecondCategory? SecondCategory { get; set; }
		public List<Elan>? Elans { get; set; }

	}
}

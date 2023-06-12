namespace tap.az.Models
{
	public class City
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Elan>? Elans { get; set; }
	}
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tap.az.Models;
using tap.az.Models.Kataqoriler;

namespace tap.az.Database
{
	public class MyDbContext : IdentityDbContext
	{
		public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt) { }

		public DbSet<Elan> Elans { get; set; }
		public DbSet<Category> Categorys { get; set; }
		public DbSet<SecondCategory> SecondCategorys { get; set; }
		public DbSet<Cins> Cinses { get; set; }
		public DbSet<MalinNovu> MalinNovleri { get; set; }
		public DbSet<Marka> Markas { get; set; }
		public DbSet<Model> Models { get; set; }
		public DbSet<City> cities { get; set; }

		public DbSet<AppUser> AppUsers { get; set; }
	}
}

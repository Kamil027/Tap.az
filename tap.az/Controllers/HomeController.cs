using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tap.az.Database;
using tap.az.Models;

namespace tap.az.Controllers
{
	public class HomeController : Controller
	{
		private readonly MyDbContext _myDb;

		public HomeController(MyDbContext myDb)
		{
			_myDb = myDb;
		}


		public IActionResult Index()
		{
			List<Elan> elans = _myDb.Elans.Include(x => x.City).ToList();
			return View(elans);
		}










	}
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using tap.az.Database;
using tap.az.Models;

namespace tap.az.Areas.manage.Controllers
{

	[Area("manage")]
	[Authorize(Roles = "SuperAdmin")]

	public class ElanController : Controller
	{
		private readonly MyDbContext _myDb;
		private readonly IWebHostEnvironment _env;

		public ElanController(MyDbContext myDb, IWebHostEnvironment env)
		{
			_myDb = myDb;
			_env = env;
		}
		public IActionResult Index()
		{
			List<Elan> list = _myDb.Elans.Include(x=> x.City).ToList();
			return View(list);
		}
	}
}

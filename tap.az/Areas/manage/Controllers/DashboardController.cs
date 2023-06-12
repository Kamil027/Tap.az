using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tap.az.Database;
using tap.az.Models;

namespace tap.az.Areas.manage.Controllers
{

	[Area("manage")]
	[Authorize(Roles = "SuperAdmin")]

	public class DashboardController : Controller
	{

		private readonly MyDbContext _myDb;
		private readonly IWebHostEnvironment _env;

		public DashboardController(MyDbContext myDb, IWebHostEnvironment env)
		{
			_myDb = myDb;
			_env = env;
		}




		public IActionResult Index()
		{	
			return View();
		}



	}
}

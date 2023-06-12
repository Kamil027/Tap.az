using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using tap.az.Database;
using tap.az.Models;
using tap.az.Models.Kataqoriler;
using tap.az.ViewModels;

namespace tap.az.Controllers
{
	[Authorize(Roles = "SuperAdmin" + "," + "Admin" + "," + "Member")]
	public class PostController : Controller
	{
		private readonly MyDbContext _myDb;
		private readonly IWebHostEnvironment _env;
		private readonly UserManager<AppUser> _userManager;

		public PostController(UserManager<AppUser> userManager, MyDbContext myDb, IWebHostEnvironment env)
		{
			_myDb = myDb;
			_env = env;
			_userManager = userManager;
		}




		public JsonResult ShowSecondCategory(int id)
		{
			var Second = _myDb.SecondCategorys.Where(x => x.CategoryId == id).ToList();
			return Json(new SelectList(Second, "Id", "Name"));
		}



		public JsonResult ShowMarks(int id)
		{
			var Marka = _myDb.Markas.Where(x => x.SecondCategoryId == id).ToList();
			return Json(new SelectList(Marka, "Id", "Name"));
		}



		public JsonResult ShowCins(int id)
		{
			var Cins = _myDb.Cinses.Where(x => x.SecondCategoryId == id).ToList();
			return Json(new SelectList(Cins, "Id", "Name"));
		}


		public JsonResult ShowMalinNovu(int id)
		{
			var Mal = _myDb.MalinNovleri.Where(x => x.SecondCategoryId == id).ToList();
			return Json(new SelectList(Mal, "Id", "Name"));
		}

		public JsonResult ShowModel(int id)
		{
			var Model = _myDb.Models.Where(x => x.MarkaId == id).ToList();
			return Json(new SelectList(Model, "Id", "Name"));
		}








		public IActionResult index()
		{
			List<Elan> elans = _myDb.Elans.Include(x => x.City).Where(x => x.AppUserId == _userManager.GetUserId(User)).ToList();
			return View(elans);
		}










		public IActionResult Create()
		{
			ViewBag.category = new SelectList(_myDb.Categorys.ToList(), "Id", "Name");
			ViewBag.city = new SelectList(_myDb.cities.ToList(), "Id", "Name");
			return View();
		}


		[HttpPost]
		public IActionResult Create(AddElanViewModel ElanViewModel)
		{

			ViewBag.city = new SelectList(_myDb.cities.ToList(), "Id", "Name");
			ViewBag.category = new SelectList(_myDb.Categorys.ToList(), "Id", "Name");

			if (!ModelState.IsValid) { return View(); }

			if ((ElanViewModel.AddFirstCategoryId == 1 || ElanViewModel.AddFirstCategoryId == 2) && ElanViewModel.AddFourthCategoryId == null)
			{
				ModelState.AddModelError("AddFourthCategoryId", "Seçiminizi edin!");
				return View();
			}


			if (ElanViewModel.AddImageFile != null)
			{
				if (ElanViewModel.AddImageFile.ContentType != "image/jpeg" && ElanViewModel.AddImageFile.ContentType != "image/png")
				{
					ModelState.AddModelError("imagefile", "yalniz sekil ola biler");
					return View();
				}

				if (ElanViewModel.AddImageFile.Length >= 3145728)
				{
					ModelState.AddModelError("imagefile", "3 mb dan boyuk olmaz");
					return View();
				}

				ElanViewModel.AddImageUrl = FileManager.SaveFile(_env.WebRootPath, "upload/elan", ElanViewModel.AddImageFile);

			}
			else
			{
				ModelState.AddModelError("imagefile", "sekil elave edin");
				return View();
			}


			Elan newElan = new Elan();
		
			newElan.AppUserId = _userManager.GetUserId(User); 
			newElan.ElanName = ElanViewModel.AddElanName;
			newElan.CityId = ElanViewModel.AddCityId;
			newElan.Price = ElanViewModel.AddPrice;
			newElan.Description= ElanViewModel.AddDescription;
			newElan.ImageUrl= ElanViewModel.AddImageUrl;
			newElan.Name = ElanViewModel.AddPersonName;
			newElan.Phone = ElanViewModel.AddPhoneNumber;
			newElan.Date = DateTime.UtcNow;
			newElan.Email= ElanViewModel.AddEmail;





			if (ElanViewModel.AddFirstCategoryId == 1 && ElanViewModel.AddFirstCategoryId == 2)
			{
				newElan.ModelId = ElanViewModel.AddFourthCategoryId;
			}
			else if (ElanViewModel.AddFirstCategoryId == 3)
			{
				newElan.CinsId = ElanViewModel.AddThirdCategoryId;
			}
			else if (ElanViewModel.AddFirstCategoryId == 4)
			{
				newElan.MalinNovuId = ElanViewModel.AddThirdCategoryId;
			}



			_myDb.Elans.Add(newElan);
			_myDb.SaveChanges();
			return RedirectToAction("index", "home");

		}






		public IActionResult Update(int id)
		{
			ViewBag.city = new SelectList(_myDb.cities.ToList(), "Id", "Name");
			ViewBag.category = new SelectList(_myDb.Categorys.ToList(), "Id", "Name");

			Elan elan = _myDb.Elans.FirstOrDefault(x=>x.Id== id);

			if(elan.AppUserId != _userManager.GetUserId(User))
			{
				return NotFound();
			}

			if (elan == null) { return NotFound();  }

			AddElanViewModel viewModel = new AddElanViewModel();

			//viewModel.AppUserId = _userManager.GetUserId(User);
			viewModel.AddElanName = elan.ElanName;
			viewModel.AddCityId = elan.CityId;
			viewModel.AddPrice = (int)elan.Price;
			viewModel.AddDescription = elan.Description;
			viewModel.AddImageUrl = elan.ImageUrl;
			viewModel.AddPersonName = elan.Name;
			viewModel.AddPhoneNumber = elan.Phone;
			viewModel.AddEmail = elan.Email;
			viewModel.Id = elan.Id;
			//viewModel.Date = DateTime.UtcNow;




			return View(viewModel);

		}


		[HttpPost]
		public IActionResult Update(AddElanViewModel viewModel)
		{
			ViewBag.city = new SelectList(_myDb.cities.ToList(), "Id", "Name");
			ViewBag.category = new SelectList(_myDb.Categorys.ToList(), "Id", "Name");

			
			if(!ModelState.IsValid) { return View(viewModel); }

			Elan exsistElan= _myDb.Elans.FirstOrDefault(x=> x.Id== viewModel.Id);

			if(exsistElan == null) { return NotFound(); }

			if(viewModel.AddImageFile != null)
			{
				if (viewModel.AddImageFile.ContentType != "image/jpeg" && viewModel.AddImageFile.ContentType != "image/png")
				{
					ModelState.AddModelError("imagefile", "yalniz sekil ola biler");
					return View();
				}

				if (viewModel.AddImageFile.Length >= 3145728)
				{
					ModelState.AddModelError("imagefile", "3 mb dan boyuk olmaz");
					return View();
				}

				if (exsistElan.ImageUrl != null)
				{
					FileManager.Delete(_env.WebRootPath, "upload/elan", exsistElan.ImageUrl);
				}

				exsistElan.ImageUrl = FileManager.SaveFile(_env.WebRootPath, "upload/elan", viewModel.AddImageFile);

			}



			//exsistElan.AppUserId = _userManager.GetUserId(User);
			exsistElan.ElanName = viewModel.AddElanName;
			exsistElan.CityId = viewModel.AddCityId;
			exsistElan.Price = viewModel.AddPrice;
			exsistElan.Description = viewModel.AddDescription;
			exsistElan.Name = viewModel.AddPersonName;
			exsistElan.Phone = viewModel.AddPhoneNumber;
			exsistElan.Date = DateTime.UtcNow;
			exsistElan.Email = viewModel.AddEmail;


			if(exsistElan.ModelId != null )
			{
				exsistElan.ModelId = null;
			}
			else if(exsistElan.MalinNovuId!= null)
			{
				exsistElan.MalinNovuId= null;
			}
			else if(exsistElan.CinsId!= null)
			{
				exsistElan.CinsId= null;
			}


		

			if (viewModel.AddFirstCategoryId == 1 && viewModel.AddFirstCategoryId == 2)
			{
				exsistElan.ModelId = viewModel.AddFourthCategoryId;
			}
			else if (viewModel.AddFirstCategoryId == 3)
			{
				exsistElan.CinsId = viewModel.AddThirdCategoryId;
			}
			else if (viewModel.AddFirstCategoryId == 4)
			{
				exsistElan.MalinNovuId = viewModel.AddThirdCategoryId;
			}



			_myDb.SaveChanges();

			return RedirectToAction("index");




		}







		public IActionResult Delete(int id)
		{
			Elan elan = _myDb.Elans.FirstOrDefault(x => x.Id == id);

			if (elan == null) { return NotFound(); }

			if ((elan.AppUserId != _userManager.GetUserId(User) ) && !(User.IsInRole("SuperAdmin")))
			{
				return NotFound();
			}

			if (elan.ImageUrl != null)
			{
				FileManager.Delete(_env.WebRootPath, "upload/elan", elan.ImageUrl);
			}

			_myDb.Elans.Remove(elan);
			_myDb.SaveChanges();
			return RedirectToAction("Index","home");
		}







	}
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using tap.az.Models;
using tap.az.ViewModels;

namespace Anyar.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly SignInManager<AppUser> _signInManager;

		public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
		}

		public IActionResult Index()
		{
			return View();
		}


		public async Task<IActionResult> CreateAdmin()
		{
			AppUser user = new AppUser
			{
				UserName = "SuperAdminKamil"
			};
			var result = await _userManager.CreateAsync(user, "Kamil000");
			return Ok(result);
		}

		public async Task<IActionResult> CreateRole()
		{
			IdentityRole role = new IdentityRole("SuperAdmin");
			IdentityRole role2 = new IdentityRole("Admin");
			IdentityRole role3 = new IdentityRole("Member");

			await _roleManager.CreateAsync(role);
			await _roleManager.CreateAsync(role2);
			await _roleManager.CreateAsync(role3);

			return Ok("added");
		}

		public async Task<IActionResult> AddRole()
		{
			AppUser user = await _userManager.FindByNameAsync("SuperAdminKamil");
			await _userManager.AddToRoleAsync(user, "SuperAdmin");
			return Ok("added");
		}


		public IActionResult Login()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel adminLogin)
		{
			if (!ModelState.IsValid) { return View(); }

			AppUser appUser = await _userManager.FindByNameAsync(adminLogin.Username);

			if (appUser == null)
			{
				ModelState.AddModelError("", "name or password is invalid");
				return View();
			}

			var result = await _signInManager.PasswordSignInAsync(appUser, adminLogin.Password, false, false);

			if (!result.Succeeded)
			{
				ModelState.AddModelError("", "name or password is invalid");
				return View();
			}


			return RedirectToAction("index", "home");
		}

		public async Task<IActionResult> Logout()
		{
			if (User.Identity.IsAuthenticated)
			{
				await _signInManager.SignOutAsync();
			}
			return RedirectToAction("index", "home");
		}

		public IActionResult Register()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel register)
		{
			if (!ModelState.IsValid) { return View(); }

			AppUser user = await _userManager.FindByNameAsync(register.Username);

			if (user != null)
			{
				ModelState.AddModelError("username", "bele nir user name sitifade olunub");
				return View();
			}

			user = await _userManager.FindByEmailAsync(register.Email);

			if (user != null)
			{
				ModelState.AddModelError("email", "bele nir user email sitifade olunub");
				return View();
			}

			user = new AppUser
			{
				UserName = register.Username,
				Email = register.Email,
			};

			var result = await _userManager.CreateAsync(user, register.Password);

			if (!result.Succeeded)
			{
				foreach (var err in result.Errors)
				{
					ModelState.AddModelError("", err.Description);
					return View();
				}
			}

			var roleresult = await _userManager.AddToRoleAsync(user, "Member");

			if (!roleresult.Succeeded)
			{
				foreach (var err in roleresult.Errors)
				{
					ModelState.AddModelError("", err.Description);
					return View();
				}
			}

			return RedirectToAction("login", "account");
		}

	}


}
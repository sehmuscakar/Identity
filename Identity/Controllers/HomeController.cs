using Identity.Entities;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace Identity.Controllers
{
	[AutoValidateAntiforgeryToken]//bu sunucu dışında belirli istekler buraya yapılamaz 
	public class HomeController : Controller
	{
		private readonly UserManager<AppUser> _userManager; //bu generic bi method
		private readonly SignInManager<AppUser> _signInManager;
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
		{
			return View();
		}

		public IActionResult Create()
		{
			return View(new UserCreateModel());//burda model geriye dönsün yani 
		}

		[HttpPost]
		public async Task<IActionResult> Create(UserCreateModel model)
		{
			if (ModelState.IsValid)
			{
				AppUser user = new()
				{
					Email = model.Email,
					Gender = model.Gender,
					UserName = model.UserName
				};

			var identityResult =await _userManager.CreateAsync(user, model.Password);
				if (identityResult.Succeeded)
				{
					return RedirectToAction("Index");
				}
				foreach(var error in identityResult.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			
			}
			return View(model);
		}

		public IActionResult SignIn()
		{
			return View(new UserSignInModel());
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(UserSignInModel model)
		{
			if (ModelState.IsValid)
			{
               
                var signInResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);//3cü, false beni hatırla paremtresi,4 cü,true kiltle paremtresi diğer önceki iki beli 
				if (signInResult.Succeeded)//signInResult tek bir sonuc döndürür 
				{
					var user = await _userManager.FindByNameAsync(model.UserName);
					var roles = await _userManager.GetRolesAsync(user);

					if (roles.Contains("Admin"))
					{
						return RedirectToAction("AdminPanel");
					}
					else
					{
						return RedirectToAction("Panel");
					}
			    }
             
            }
            return View(model);
        }

		[Authorize]//Authorize:bu sadece giriş yapmış kullanıcılar erişebilir,(Roles ="Admin,Member") bu giriş yapanlar arasında rolu admin veya Member olanlar 
        public IActionResult GetUserInfo()
		{
			var userName = User.Identity.Name;
			var role = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
			User.IsInRole("Member");
			return View();
		}
        [Authorize(Roles ="Admin")]
		public IActionResult AdminPanel()
		{
			return View();
		}

        [Authorize(Roles = "Member")]
        public IActionResult Panel()
        {
            return View();
        }

        [Authorize(Roles = "Member")]
        public IActionResult MemberPage()
        {
            return View();
        }

		public async Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index");
		}

    }
}

using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Shopping_Web_thien.Models;
using System.Security.Cryptography;
using System.Text;
using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Shopping_Web_thien.IServices;
using Shopping_Website.Services;
using System.Text.RegularExpressions;

namespace Shopping_Web_thien.Controllers
{
	public class AccountsController : Controller
	{
		private readonly ShopDbContext shopDbContext;
		public INotyfService _notyfService { get; }
		private IUserServices userServices;
		private IRoleServices roleServices;
		private readonly ICartServices cartServices;
		private readonly ICartDetailServices cartDetailServices;


		public AccountsController(INotyfService notyfService)
		{

			shopDbContext = new ShopDbContext();
			_notyfService = notyfService;
			userServices = new UserServices();
			roleServices = new RoleServices();
			cartServices = new CartServices();
			cartDetailServices = new CartDetailServices();
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(string username, string password)
		{
			//if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			//{
			//    // Handle empty or null username/password
			//    _notyfService.Error("Mời nhập mật khẩu");
			//    return RedirectToAction("Login", "Accounts");
			//}

			//bool isUsernameValid = username.Length > 6 && Regex.IsMatch(username, "^[a-zA-Z0-9]+$");
			//bool isPasswordValid = password.Length > 6 && Regex.IsMatch(password, "^[a-zA-Z0-9]+$");

			//if (!isUsernameValid || !isPasswordValid)
			//{
			//    // Handle invalid username/password format
			//    _notyfService.Error("Tên Và mật khẩu không chính xác");
			//    return RedirectToAction("Login", "Accounts");
			//}
            var user = userServices.Account(username, password);
			if (user != null)
			{
				var listCartDetail = cartDetailServices.GetAllCartDetailss();
				HttpContext.Session.SetString("username", username);
				ViewBag.listCartDetail = listCartDetail.Where(c => c.UserID == userServices.GetAllUsers().FirstOrDefault(c => c.UserName == username).UserID).ToList();
				if (roleServices.GetAllRoles().FirstOrDefault(x => x.RoleID == user.RoleID).RoleName == "Admin")
				{
					return RedirectToAction("Index", "Home", new { area = "Admin" });
				}
				else
				{
					_notyfService.Success("Đăng Nhập  thành công");
					return RedirectToAction("Index", "Home");

				}
			}
			else
			{
				return RedirectToAction("Login", "Accounts");
			}

		}
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();//remove session
			_notyfService.Success("Đăng xuất thành công");

			return RedirectToAction("Index", "Home");

		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]

		public IActionResult Register(string username, string password, string confirmPassword)
		{
			if (userServices.GetAllUsers().FirstOrDefault(c => c.UserName == username) == null)
			{
				if (password != confirmPassword)
				{
					return RedirectToAction("Register", "Accounts");
				}
				else
				{
					var user = new User();

					user.UserName = username;
					user.PassWord = password;
					user.Status = 1;
					user.RoleID = Guid.Parse("a459fbf0-ac8f-4ea2-76a8-08db3546e46c");
					userServices.CreateUser(user);
					cartServices.CreateCart(new Cart
					{
						UserID = user.UserID,
						Description = "ok",
					});
					_notyfService.Success("Đăng kí thành công");

				}

			}
			return RedirectToAction("Login", "Accounts");
		}

	}
}

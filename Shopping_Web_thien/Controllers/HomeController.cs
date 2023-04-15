using Microsoft.AspNetCore.Mvc;
using Shopping_Web_thien.IServices;
using Shopping_Web_thien.Models;
using Shopping_Website.Services;
using System.Diagnostics;

namespace Shopping_Web_thien.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private IProductServices productServices;
		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
			productServices = new ProductServices();

		}


		public IActionResult Index()
		{
			var a = productServices.GetAllProducts().ToList();
			ViewData["username"] = HttpContext.Session.GetString("username");
			return View(a);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Loc(string username)
		{
			var a = productServices.GetProducsByName(username);
			return View(a);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
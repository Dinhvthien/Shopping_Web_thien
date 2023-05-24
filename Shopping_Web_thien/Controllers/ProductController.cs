using Microsoft.AspNetCore.Mvc;
using Shopping_Web_thien.IServices;
using Shopping_Website.Services;

namespace Shopping_Web_thien.Controllers
{
	public class ProductController : Controller
	{
		private IProductServices productServices;
		public ProductController()
		{
			productServices = new ProductServices();
		}
		public IActionResult Index()
		{
			var a = productServices.GetAllProducts().ToList();
			return View();
		}


		public IActionResult Showsp12(string ten)
		{
		
			if (ten == ""||ten == null)
			{
				var a = productServices.GetAllProducts();
				return View(a);
			}
			else
			{
				var b = productServices.GetProducsByName(ten);
				return View(b);
			}
		
			
		}
		[HttpGet]

		public IActionResult Details(Guid id)
		{
			var a = productServices.GetProductById(id);
			ViewData["username"] = HttpContext.Session.GetString("username");
			return View(a);
		}


	}
}

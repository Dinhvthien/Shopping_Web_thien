using Microsoft.AspNetCore.Mvc;
using Shopping_Web_thien.IServices;
using Shopping_Web_thien.Models;
using Shopping_Website.Services;

namespace Shopping_Web_thien.Controllers
{
	public class CartController : Controller
	{
		private readonly IProductServices productServices;
		private readonly ICartDetailServices cartDetailServices;
		private readonly IUserServices userServices;
		public CartController()
		{
			productServices = new ProductServices();
			cartDetailServices=  new CartDetailServices();
            userServices = new UserServices();
        }
		bool checkSp(Guid idsp , Guid Userid)
		{
          
            var a = cartDetailServices.GetAllCartDetailss().FirstOrDefault(c => c.IDSP == idsp && c.UserID == Userid);
            if(a != null)
			{
				return true;
			}return false;
		}

		[HttpPost]
		public IActionResult AddToCart(Guid IDsp, int quantity)
		{
			string a = HttpContext.Session.GetString("username");

			if (quantity == null)
			{
				quantity = 1;
			}

			if (a == null)
			{
				return RedirectToAction("Login", "Accounts");
			}
            Guid user = userServices.GetAllUsers().FirstOrDefault(c => c.UserName == HttpContext.Session.GetString("username")).UserID;
            if (checkSp(IDsp, user))
			{
				var cartDetail = cartDetailServices.GetAllCartDetailss().FirstOrDefault(c=>c.IDSP == IDsp &&c.UserID == user);
				cartDetail.Quantity += quantity;
				cartDetailServices.UpdateCartDetails(cartDetail);
				return RedirectToAction("ShowCart", "Cart");
			}
			else
			{
				var sp = productServices.GetAllProducts().FirstOrDefault(c => c.Id == IDsp);
				var cartDetail = new CartDetails();
				cartDetail.ID = Guid.NewGuid();
				cartDetail.Quantity = quantity;
				cartDetail.IDSP = sp.Id;
				cartDetail.UserID = user;
				cartDetailServices.CreateCardetail(cartDetail);
				return RedirectToAction("ShowCart", "Cart");
			}
		}
		public IActionResult ShowCart()
		{
			Guid userId = userServices.GetAllUsers().FirstOrDefault(c => c.UserName == HttpContext.Session.GetString("username")).UserID;
			var show = cartDetailServices.GetAllCartDetailss().FindAll(c=>c.UserID == userId);
			//var productinCart = productServices.GetAllProducts().FindAll(c=>c.Id = )
			int a = cartDetailServices.GetAllCartDetailss().Where(c => c.UserID == userId).Count();
			HttpContext.Session.SetInt32("a", a);
			ViewData["a"]= HttpContext.Session.GetInt32("a");
			var product = productServices.GetAllProducts();
			ViewBag.showProduct = product;
			ViewBag.showlistCartDetail = show;
			return View(show);
		}

		
		public IActionResult DeletecartDetail(Guid id)
		{
			cartDetailServices.DeleteCartDetails(id);
			return RedirectToAction("ShowCart", "Cart");
		}
		public IActionResult DeleteAllcartDetails(Guid id)
		{
			var cartDetail = cartDetailServices.GetAllCartDetailss().Find(c=>c.ID== id);
			cartDetailServices.DeleteCartDetailsa(cartDetail);
			return RedirectToAction("ShowCart", "Cart");
		}

		public IActionResult UpdateQuantityInCart(int quantity,string idsp,string id)
		{
			var a = cartDetailServices.GetAllCartDetailss().FirstOrDefault(c => c.IDSP == Guid.Parse("idsp") && c.ID == Guid.Parse("id"));
			a.Quantity = quantity;
			cartDetailServices.UpdateCartDetails(a);
			return RedirectToAction("ShowCart", "Cart");
        }
	}
}

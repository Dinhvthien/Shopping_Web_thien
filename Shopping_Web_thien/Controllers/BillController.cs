using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping_Web_thien.IServices;
using Shopping_Web_thien.Models;
using Shopping_Website.Services;

namespace Shopping_Web_thien.Controllers
{
	public class BillController : Controller
	{
		private readonly IUserServices userServices;
		private readonly IBillServices billServices;
		private readonly IBillDtailServices billDtailServices;
		private readonly ICartDetailServices cartDetailServices;
		private readonly IProductServices productServices;
		public BillController()
		{
			userServices = new UserServices();
			billServices = new BillServices();
			billDtailServices = new BillDetailServices();
			cartDetailServices = new CartDetailServices();
			productServices = new ProductServices();
		}
		public Guid IdBill { get; set; }
		public IActionResult CreateBill()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateBill(string adress,string phone,string name )
		{
			string a = HttpContext.Session.GetString("username");
			Guid userid = userServices.GetAllUsers().FirstOrDefault(c => c.UserName == HttpContext.Session.GetString("username")).UserID;
			Bill bill = new Bill();
			IdBill = bill.Id = Guid.NewGuid();
			 bill.UserID = userid;
			bill.Status= 1;
			bill.CreateDate= DateTime.Now;
			bill.recipientPhone = phone;
			bill.recipientName = name;
			bill.recipientAddress = adress;
			if (billServices.CreateBill(bill))
			{
				List<CartDetails> car = cartDetailServices.GetAllCartDetailss().FindAll(c => c.UserID == userid);
				foreach(CartDetails p in car)
				{
					// Trừ số lượng sản phẩm đã bán khỏi số lượng sản phẩm trong giỏ hàng
					Product product = productServices.GetProductById(p.IDSP);
					product.avaliabaleQuantity -= p.Quantity;

					// Cập nhật thông tin sản phẩm trong cơ sở dữ liệu
					productServices.UpdateProduct(product);
					cartDetailServices.DeleteCartDetails(p.ID);
				}
			}
			
			
			var cartDetails = cartDetailServices.GetAllCartDetailss().Where(c => c.UserID == userid);

			foreach (var CartDetail in cartDetails)
			{
				var product = productServices.GetAllProducts().FirstOrDefault(p => p.Id == CartDetail.IDSP);
				BillDetails billDetails = new BillDetails();
				billDetails.Id = Guid.NewGuid();
				billDetails.IDSP = CartDetail.IDSP;
				billDetails.IDHD = IdBill;
				billDetails.Quantity = CartDetail.Quantity;
				billDetails.Price = product.Price* CartDetail.Quantity;
				billDtailServices.CreateBillDetail(billDetails);
			}
			return RedirectToAction("Home", "Index");
		}


		public IActionResult ShowBill()
		{
			string a = HttpContext.Session.GetString("username");
			Guid userid = userServices.GetAllUsers().FirstOrDefault(c => c.UserName == HttpContext.Session.GetString("username")).UserID;
			var billsa = billServices.GetAllBills().Where(c => c.UserID == userid).ToList();
			List<SelectListItem> listGh = new List<SelectListItem>();
			listGh.Add(new SelectListItem() { Text = "Đã hủy", Value = "1" });
			listGh.Add(new SelectListItem() { Text = "Đang xác nhận", Value = "2" });
			listGh.Add(new SelectListItem() { Text = "Đang vận chuyển", Value = "3" });
			listGh.Add(new SelectListItem() { Text = "Giao thành công", Value = "4" });
			ViewData["TrangThai"] = listGh;
			return View(billsa);
		}


	}
}

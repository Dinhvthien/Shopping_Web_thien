using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Mvc;
using Shopping_Web_thien.IServices;
using Shopping_Web_thien.Models;
using Shopping_Website.Services;

namespace Shopping_Web_thien.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BillController : Controller
	{
		private readonly IBillServices billServices;
        private readonly IUserServices userServices;
        public INotyfService _notyfService { get; }
        public BillController(INotyfService notyfService)
        {
			billServices = new BillServices();
            userServices = new UserServices();
			_notyfService = notyfService;
        }
		public IActionResult ShowBillAll()
		{
			var a = billServices.GetAllBills().ToList();
			return View(a);
		}
        [HttpGet]
        public IActionResult UpdateBill(Guid id) // Mở form, truyền luôn sang form
        {
            var role = billServices.GetBillById(id);
            return View(role);
        }
        public IActionResult UpdateBill(Bill r) // Mở form
        {
			if (billServices.UpdateBill(r))
            {
                _notyfService.Success("Cập nhật thành công");
                return RedirectToAction("ShowBillAll", "Bill", new {area = "Admin"});
            }
            else
            {
                _notyfService.Error("Có lỗi xẩy ra");
                return BadRequest();
            }
        }
        public IActionResult DeleteBill(Guid id)
        {
            billServices.DeleteBill(id);
            _notyfService.Success("Xóa thành công");
            return RedirectToAction("ShowBillAll", "Bill", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult DetailsBill(Guid id)
        {
            var Role = billServices.GetBillById(id);
            return View(Role);
        }
    }
}

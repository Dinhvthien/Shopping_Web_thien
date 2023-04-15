using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using Microsoft.AspNetCore.Mvc;
using Shopping_Web_thien.IServices;
using Shopping_Web_thien.Models;
using Shopping_Website.Services;

namespace Shopping_Web_thien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private IProductServices productServices;
        private IRoleServices RoleServices;
        private IUserServices UserServices;
        private IBillServices BillServices;
        private IBillDtailServices billDtailServices;
        private ICartServices CartServices;
        private ICartDetailServices cartDetailServices;
        public INotyfService _notyfService { get; }
        public RoleController(ILogger<RoleController> logger , INotyfService notyfService)
        {
            _logger = logger;
            productServices = new ProductServices();
            RoleServices = new RoleServices();
            UserServices = new UserServices();
            BillServices = new BillServices();
            billDtailServices = new BillDetailServices();
            CartServices = new CartServices();
            cartDetailServices = new CartDetailServices();
            _notyfService = notyfService;
        }
        public IActionResult ListRole()
        {
            var a = RoleServices.GetAllRoles().ToList();
            return View(a);
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateRole(Role role)
        {

            RoleServices.CreateRole(role);
            _notyfService.Success("Tạo mới thành công");
            return RedirectToAction("ListRole");
        }
        [HttpGet]
        public IActionResult UpdateRole(Guid id) // Mở form, truyền luôn sang form
        {
            var role = RoleServices.GetRoleById(id);
            return View(role);
        }
        public IActionResult UpdateRole(Role r) // Mở form
        {
            if (RoleServices.UpdateRole(r))
            {
                _notyfService.Success("Cập nhật thành công");
                return RedirectToAction("ListRole");
            }
            else
            {
                _notyfService.Success("Có lỗi xẩy ra");
                return BadRequest(); 
            }
        }
        public IActionResult DeleteRole(Guid id)
        {
            RoleServices.DeleteRole(id);
            _notyfService.Success("Xóa thành công");
            return RedirectToAction("ListRole");
        }
        [HttpGet]
        public IActionResult DetailsRole(Guid id)
        {
            var Role = RoleServices.GetRoleById(id);
            return View(Role);
        }
    }
}

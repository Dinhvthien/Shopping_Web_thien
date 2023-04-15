using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shopping_Web_thien.IServices;
using Shopping_Web_thien.Models;
using Shopping_Website.Services;

namespace Shopping_Web_thien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ShopDbContext _dbContext;
        private IProductServices productServices;
        private IRoleServices RoleServices;
        private IUserServices UserServices;
        private IBillServices BillServices;
        private IBillDtailServices billDtailServices;
        private ICartServices CartServices;
        private ICartDetailServices cartDetailServices;
        public UserController()
        {
         
            _dbContext = new ShopDbContext();
            productServices = new ProductServices();
            RoleServices = new RoleServices();
            UserServices = new UserServices();
            BillServices = new BillServices();
            billDtailServices = new BillDetailServices();
            CartServices = new CartServices();
            cartDetailServices = new CartDetailServices();
        }
        public IActionResult Index()
        {
            ViewData["QuyenTruyCap"] = new SelectList(_dbContext.Roles, "RoleID", "Description");

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() {Text="Hoạt Động" , Value="1" });
            list.Add(new SelectListItem() { Text = "Không Hoạt Động", Value = "0" });
            ViewData["TrangThai"] = list;
            var a = UserServices.GetAllUsers().ToList();
            return View(a);
        }
    }
}

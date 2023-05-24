using Microsoft.AspNetCore.Mvc;
using Shopping_Web_thien.IServices;
using Shopping_Web_thien.Models;
using Shopping_Web_thien.Services;
using Shopping_Website.Services;

namespace Shopping_Web_thien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private IProductServices productServices;
        private IRoleServices RoleServices;
        private IUserServices UserServices;
        private IBillServices BillServices;
        private IBillDtailServices billDtailServices;
        private ICartServices CartServices;
        private ICartDetailServices cartDetailServices;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            productServices = new ProductServices();
            RoleServices = new RoleServices();
            UserServices = new UserServices();
            BillServices = new BillServices();
            billDtailServices = new BillDetailServices();
            CartServices = new CartServices();
            cartDetailServices = new CartDetailServices();
        }
        public IActionResult ShowListProduct()
        {
            var a = productServices.GetAllProducts().ToList();
            return View(a);
        }


        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateProduct(Product product)
        {
            //bool isproduct = productServices.GetAllProducts().Any(c => c.Name == product.Name && c.Supplier == product.Supplier);
            //if (!isproduct)
            //{
            //    return Content("Hoc lai");
            //}

            productServices.CreateProduct(product);
            return RedirectToAction("ShowListProduct", "Product", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult UpdateProdoct(Guid id) // Mở form, truyền luôn sang form
        {
            //var role = productServices.GetProductById(id);
            //return View(role);

            var oldProduct = productServices.GetProductById(id);

            //List<Product> products = new List<Product>();
            //products.Add(oldProduct);
            //SessionService.SetObjToSession(HttpContext.Session, "ListOldProduct", products);
            //return View(oldProduct);
            // Doc tu session danh sach san pham trong cart
            var products = SissionServices.GetObjFromSession(HttpContext.Session, "Cart");
            if (products.Count == 0)
            {
                products.Add(oldProduct);
                SissionServices.SetObjToSession(HttpContext.Session, "Cart", products);
            }
            else
            {
                if (SissionServices.CheckExistProduct(id, products))
                {

                    return View(oldProduct);
                }
                else
                {
                    products.Add(oldProduct);
                    SissionServices.SetObjToSession(HttpContext.Session, "Cart", products);
                }
            }

            return View(oldProduct);
        }
        public IActionResult UpdateProdoct(Product r) // Mở form
        {
            if (productServices.UpdateProduct(r))
            {
                return RedirectToAction("ShowListProduct", "Product", new { area = "Admin" });
            }
            else return BadRequest();
        }
        public IActionResult ShowListOldProduct()
        {
            // Doc session ListOldProduct
            var test = HttpContext.Session.GetComplexData<List<Product>>("Cart");
            return View(test);
        }

        public IActionResult Rollback(Guid Id)
        {
            // Lấy sản phẩm cần RollBack
            Product product = productServices.GetProductById(Id);

            // Lấy giá trị cũ từ TempData

            var products = SissionServices.GetObjFromSession(HttpContext.Session, "Cart");
            var oldProduct = products.FirstOrDefault(p => p.Id == Id);

            // Gán lại giá trị cũ cho sản phẩm
            productServices.UpdateProduct(oldProduct);

            // Trả về view để hiển thị sản phẩm sau khi RollBack
            return RedirectToAction("ShowListProduct", "Product");
        }

        public IActionResult ShowListOldProductDelete(string name)
        {
			if(name == null && name == "")
            {
				return RedirectToAction("ShowListProduct", "Product", new { area = "Admin" });
            }
            else
            {
                var s = productServices.GetProducsByName(name).ToList();
				return RedirectToAction("ShowListOldProductDelete", "Product", new { area = "Admin" });
			}
			
		}

        public IActionResult Rollback2(Guid Id)
        {
            //var product = SissionServices.GetObjFromSession(HttpContext.Session, "asda");
            //var oldProduct = product.FirstOrDefault(c => c.Id == Id);
            //productServices.CreateProduct(oldProduct);
            return RedirectToAction("ShowListProduct", "Product");
        }

        public IActionResult DeleteProduct(Guid id)
        {
            //var oldproduct = productServices.GetProductById(id);
            //var product = SissionServices.GetObjFromSession(HttpContext.Session, "asda");
            //if (product.Count == 0)
            //{
            //    product.Add(oldproduct);
            //    SissionServices.SetObjToSession(HttpContext.Session, "asda", product);
            //}
            productServices.DeleteProduct(id);
            return RedirectToAction("ShowListProduct");
        }
        [HttpGet]
        public IActionResult DetailsProduct(Guid id)
        {
            var Role = productServices.GetProductById(id);
            return View(Role);
        }

   

    }
}

using Microsoft.AspNetCore.Mvc;

namespace Shopping_Web_thien.Areas.tonggiadoc.Controllers
{
    [Area("tonggiadoc")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

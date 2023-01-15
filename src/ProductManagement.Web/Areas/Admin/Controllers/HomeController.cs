using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Insert()
        {
            return View();
        }
    }
}

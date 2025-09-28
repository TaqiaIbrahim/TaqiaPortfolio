using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddOrEdit()
        {
            return View();
        }
    }
}

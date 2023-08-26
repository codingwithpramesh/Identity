using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

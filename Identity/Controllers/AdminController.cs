using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }
    }
}

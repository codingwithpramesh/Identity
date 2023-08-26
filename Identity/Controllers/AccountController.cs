using Identity.Data;
using Identity.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(LoginVm loginvm)
        {
            if(!ModelState.IsValid)
            {
                return View(loginvm);
            }
            var result = await _context.LoginAsync
            return View();
        }
    }
}

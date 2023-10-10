using Identity.Data;
using Identity.Models;
using Identity.Models.ViewModel;
using Identity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAuthenticationService _service;
        public AccountController(IUserAuthenticationService service)
        {
            _service = service;
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

            var data = await _service.Login(loginvm);

            if(data.statuscode == 1) 
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

          //  var result = await _context.LoginAsync;
           
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public  async Task<IActionResult> Register( Register register)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                register.Role = "user";
                var re =  await _service.Register(register);
                return RedirectToAction("Register","Account");

            }
        }

        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction("Login", "Account");
        }


        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }


       
        /* public async Task<IActionResult> Reg()
         {
             var model = new Register()
             {
                 username = "admin",
                 Name = "pramesh",
                 Email = "admin@gmail.com",
                 Password = "password"

             };

             model.Role = "user";
             var result = await _service.Register(Register)
         }*/


    }
}

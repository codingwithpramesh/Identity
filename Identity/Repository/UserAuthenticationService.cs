using Identity.Models;
using Identity.Models.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace Identity.Repository
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        /*  private readonly SignInManager<ApplicationUser> _signInManager;
          private readonly UserManager<ApplicationUser> _userManager;
          private readonly RoleManager<ApplicationUser> _roleManager;
          public UserAuthenticationService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationUser> roleManager, SignInManager<ApplicationUser> signInManager)
          {
              _userManager=userManager;
              _roleManager=roleManager;
              _signInManager=signInManager;

          }*/

       

        public UserAuthenticationService()
        {
            
        }
        public Task<Status> Login(LoginVm vm)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Status> Register(Register vm)
        {
           var status = new Status();
            var userExists = await _userManager.FindByNameAsync();
            if (userExists != null)
            {
                status.statuscode = 0;
                status.message="User is Exists";
                return status;

            }

            ApplicationUser user = new ApplicationUser();
            
        }
    }
}

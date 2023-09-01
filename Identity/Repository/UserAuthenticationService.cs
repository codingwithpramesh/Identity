using Identity.Models;
using Identity.Models.ViewModel;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Identity.Repository
{
    public class UserAuthenticationService : IUserAuthenticationService
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserAuthenticationService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager=signInManager;
            _roleManager=roleManager;
            _userManager=userManager;

        }

        public async Task<Status> Login(LoginVm vm)
        {
            var status = new Status();
            var user = await _userManager.FindByNameAsync(vm.Username);
            if (user == null)
            {
                status.statuscode=0;
                status.message = "Invalid User";
                return status;
            }

            if (!await _userManager.CheckPasswordAsync(user, vm.Password))
            {
                status.statuscode=0;
                status.message ="Invalid Password";
                return status;
            }

            var signinResult = await _signInManager.PasswordSignInAsync(user, vm.Password, false, true);
            if (signinResult.Succeeded)
            {
                var userroles = await _userManager.GetRolesAsync(user);
                var authclaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, vm.Username)

                };

                foreach (var userrole in userroles)
                {
                    authclaims.Add(new Claim(ClaimTypes.Role, userrole));

                }
                status.statuscode = 1;
                status.message = "Login Successfully";
                return status;
            }
            else if (signinResult.IsLockedOut)
            {
                status.statuscode=0;
                status.message = "User Lockout";
            }
            else
            {
                status.statuscode =0;
                status.message="Invalid User";
                return status;

            }

            return status;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<Status> Register(Register model)
        {
            var status = new Status();
            var userExists = await _userManager.FindByNameAsync(model.username);
            if (userExists != null)
            {
                status.statuscode = 0;
                status.message = "User already exist";
                return status;
            }
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.username,
                Name = model.Name,
                EmailConfirmed=true,
                PhoneNumberConfirmed=true,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                status.statuscode = 0;
                status.message = "User creation failed";
                return status;
            }

            if (!await _roleManager.RoleExistsAsync(model.Role))
                await _roleManager.CreateAsync(new IdentityRole(model.Role));


            if (await _roleManager.RoleExistsAsync(model.Role))
            {
                await _userManager.AddToRoleAsync(user, model.Role);
            }

            status.statuscode = 1;
            status.message = "You have registered successfully";
            return status;
        }
        public async Task<Status> ChangePasswordAsync(ChangePasswordModel model, string username)
        {
            var status = new Status();

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                status.message = "User does not exist";
                status.statuscode = 0;
                return status;
            }
            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (result.Succeeded)
            {
                status.message = "Password has updated successfully";
                status.statuscode = 1;
            }
            else
            {
                status.message = "Some error occcured";
                status.statuscode = 0;
            }
            return status;

        }

       


    }
}



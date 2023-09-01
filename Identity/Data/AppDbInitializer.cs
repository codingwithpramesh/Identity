using Identity.Data.Static;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.Contracts;

namespace Identity.Data
{
    public class AppDbInitializer
    {

        public static async Task SeedUserandRolesAsync (IApplicationBuilder applicationBuilder)
        {
            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var rolemanager = servicescope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await rolemanager.RoleExistsAsync(UserRoles.Admin))
                    await rolemanager.CreateAsync(new IdentityRole(UserRoles.Admin));
                else if(!await rolemanager.RoleExistsAsync(UserRoles.User))
                    await rolemanager.CreateAsync(new IdentityRole(UserRoles.User));    


            }
        }

    }
}

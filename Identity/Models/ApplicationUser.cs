using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class ApplicationUser : IdentityUser
    {

        public int Name { get; set; }

        public string ProfilePicture { get; set; }
    }
}

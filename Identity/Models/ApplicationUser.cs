using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Identity.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Name { get; set; }
        public string? ProfilePicture { get; set; }
    }
}

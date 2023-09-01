using System.ComponentModel.DataAnnotations;

namespace Identity.Models.ViewModel
{
    public class LoginVm
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

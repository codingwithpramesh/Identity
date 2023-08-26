namespace Identity.Models
{
    public class Register
    {

        public string Name { get; set; }
        public string Email { get; set; }

        public string username { get; set; }
        public string Password { get; set; }

        public string passwordConfirm { get; set; }

        public string?  Role { get; set; }
    }
}

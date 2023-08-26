using Identity.Models;
using Identity.Models.ViewModel;

namespace Identity.Repository
{
    public interface IUserAuthenticationService
    {

        Task<Status> Login(LoginVm vm);

        Task<Status> Register(Register vm);

        Task LogoutAsync();
    }
}

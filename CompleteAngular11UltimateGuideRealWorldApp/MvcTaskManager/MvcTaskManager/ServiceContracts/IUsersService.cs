using MvcTaskManager.Models;
using MvcTaskManager.ViewModels;
using System.Threading.Tasks;

namespace MvcTaskManager.ServiceContracts
{
    public interface IUsersService
    {
        Task<ApplicationUser> Authenticate(LoginViewModel loginViewModel);
    }
}

using System.Threading.Tasks;
using Wallet.Contracts.Requests;

namespace Wallet.UI
{
    public interface IAuthenticationService
    {
        Task<bool> Login(LoginRequest loginRequest);

        Task Logout();

        Task<bool> Register(RegistrationRequest registrationRequest);
    }
}
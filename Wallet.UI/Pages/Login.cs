using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Wallet.Contracts.Requests;

namespace Wallet.UI.Pages
{
    public partial class Login
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        public string ErrorMessage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public LoginRequest Request { get; set; } = new();

        protected async Task LoginAsync()
        {
            ErrorMessage = null;

            var success = await AuthenticationService.LoginAsync(Request);

            if (success)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                ErrorMessage = "Hiba történt a bejelentkezés során.";
            }
        }
    }
}
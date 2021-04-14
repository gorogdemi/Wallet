using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Wallet.Contracts.Requests;

namespace Wallet.UI.Pages
{
    public partial class Register
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        public string ErrorMessage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public RegistrationRequest Request { get; set; } = new();

        protected async Task RegisterAsync()
        {
            ErrorMessage = null;

            var success = await AuthenticationService.RegisterAsync(Request);

            if (success)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                ErrorMessage = "Hiba történt a regisztráció során.";
            }
        }
    }
}
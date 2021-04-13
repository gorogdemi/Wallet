using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Wallet.Contracts.Requests;
using Wallet.UI.Services;

namespace Wallet.UI.Pages.Transactions
{
    public partial class Create
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public TransactionRequest Transaction { get; private set; } = new TransactionRequest { Date = DateTime.Now };

        [Inject]
        public ITransactionService TransactionService { get; set; }

        protected string ErrorMessage { get; private set; }

        protected async Task CreateAsync()
        {
            var result = await TransactionService.CreateAsync(Transaction);
            if (!result)
            {
                ErrorMessage = "Sikertelen tranzakció!";
            }
            else
            {
                NavigateToTransactions();
            }
        }

        protected void NavigateToTransactions() => NavigationManager.NavigateTo("transactions");

        protected override async Task OnInitializedAsync()
        {
            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            Transaction.UserId = state.User.FindFirst("id").Value;
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Wallet.Contracts.Requests;
using Wallet.UI.Services;

namespace Wallet.UI.Pages.Transactions
{
    [Authorize]
    public partial class Edit
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int TransactionId { get; set; }

        public TransactionRequest TransactionRequest { get; private set; } = new();

        [Inject]
        public ITransactionService TransactionService { get; set; }

        protected string ErrorMessage { get; private set; }

        protected async Task EditAsync()
        {
            var result = await TransactionService.UpdateAsync(TransactionId, TransactionRequest);
            if (!result)
            {
                ErrorMessage = "Sikertelen tranzakció módosítás!";
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
            var userId = state.User.FindFirst("id").Value;

            var transactionResponse = await TransactionService.GetAsync(TransactionId);

            TransactionRequest = new TransactionRequest
            {
                BankAmount = transactionResponse.BankAmount,
                CashAmount = transactionResponse.CashAmount,
                CategoryId = transactionResponse.CategoryId,
                Comment = transactionResponse.Comment,
                Date = transactionResponse.Date,
                Name = transactionResponse.Name,
                Type = transactionResponse.Type,
                UserId = userId
            };
        }
    }
}
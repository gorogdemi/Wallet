using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Wallet.Contracts.Requests;
using Wallet.Contracts.Responses;
using Wallet.UI.Services;

namespace Wallet.UI.Pages.Transactions
{
    public partial class Edit
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public TransactionResponse Transaction { get; private set; }

        [Parameter]
        public string TransactionId { get; set; }

        [Inject]
        public ITransactionService TransactionService { get; set; }

        protected string ErrorMessage { get; private set; }

        protected async Task EditAsync()
        {
            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var userId = state.User.FindFirst("id").Value;

            var request = new TransactionRequest
            {
                BankAmount = Transaction.BankAmount,
                CashAmount = Transaction.CashAmount,
                CategoryId = Transaction.CategoryId,
                Comment = Transaction.Comment,
                Date = Transaction.Date,
                Name = Transaction.Name,
                Type = Transaction.Type,
                UserId = userId
            };

            var result = await TransactionService.UpdateAsync(int.Parse(TransactionId), request);
            if (!result)
            {
                ErrorMessage = "Sikertelen tranzakció módosítás!";
                return;
            }

            NavigateToTransactions();
        }

        protected void NavigateToTransactions() => NavigationManager.NavigateTo("transactions");

        protected override async Task OnInitializedAsync()
        {
            Transaction = await TransactionService.GetAsync(int.Parse(TransactionId));
        }
    }
}
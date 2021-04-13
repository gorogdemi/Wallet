using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Wallet.Contracts.Responses;
using Wallet.UI.Services;

namespace Wallet.UI.Pages.Transactions
{
    [Authorize]
    public partial class Transactions
    {
        public IEnumerable<TransactionResponse> TransactionCollection { get; private set; }

        [Inject]
        public ITransactionService TransactionService { get; set; }

        protected Task DeleteAsync(int id) => TransactionService.DeleteAsync(id);

        protected override async Task OnInitializedAsync()
        {
            TransactionCollection = await TransactionService.GetAsync();
        }
    }
}
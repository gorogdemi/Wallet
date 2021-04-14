using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Wallet.Contracts.Responses;
using Wallet.UI.Services;

namespace Wallet.UI.Pages
{
    [Authorize]
    public partial class Index
    {
        public BalanceResponse Balance { get; private set; }

        [Inject]
        public IBalanceService BalanceService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Balance = await BalanceService.GetAsync();
        }
    }
}
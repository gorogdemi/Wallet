using System.Threading.Tasks;
using Wallet.Contracts.Responses;

namespace Wallet.UI.Services
{
    internal interface IBalanceService
    {
        Task<BalanceResponse> GetAsync();
    }
}
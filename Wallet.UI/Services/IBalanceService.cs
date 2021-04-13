using System.Threading.Tasks;
using Wallet.Contracts.Responses;

namespace Wallet.UI.Services
{
    public interface IBalanceService
    {
        Task<BalanceResponse> GetAsync();
    }
}
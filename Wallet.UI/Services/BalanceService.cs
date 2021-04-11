using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Wallet.Contracts.Responses;

namespace Wallet.UI.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly HttpClient _httpClient;

        public BalanceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<BalanceResponse> GetAsync() => _httpClient.GetFromJsonAsync<BalanceResponse>("api/balance");
    }
}
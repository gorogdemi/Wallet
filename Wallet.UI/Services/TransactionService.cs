using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Wallet.Contracts.Requests;
using Wallet.Contracts.Responses;

namespace Wallet.UI.Services
{
    public class TransactionService : ITransactionService
    {
        private const string ApiUrl = "api/transactions";
        private readonly HttpClient _httpClient;

        public TransactionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateAsync(TransactionRequest request) => (await _httpClient.PostAsJsonAsync(ApiUrl, request)).IsSuccessStatusCode;

        public async Task<bool> DeleteAsync(int id) => (await _httpClient.DeleteAsync($"{ApiUrl}/{id}")).IsSuccessStatusCode;

        public Task<IEnumerable<TransactionResponse>> GetAsync() => _httpClient.GetFromJsonAsync<IEnumerable<TransactionResponse>>(ApiUrl);

        public Task<TransactionResponse> GetAsync(int id) => _httpClient.GetFromJsonAsync<TransactionResponse>($"{ApiUrl}/{id}");

        public async Task<bool> UpdateAsync(int id, TransactionRequest request) => (await _httpClient.PutAsJsonAsync($"{ApiUrl}/{id}", request)).IsSuccessStatusCode;
    }
}
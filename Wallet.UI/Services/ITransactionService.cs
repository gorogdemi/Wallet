using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Contracts.Requests;
using Wallet.Contracts.Responses;

namespace Wallet.UI.Services
{
    internal interface ITransactionService
    {
        Task<TransactionResponse> CreateAsync(TransactionRequest request);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<TransactionResponse>> GetAsync();

        Task<TransactionResponse> GetAsync(int id);

        Task<bool> UpdateAsync(int id, TransactionRequest request);
    }
}
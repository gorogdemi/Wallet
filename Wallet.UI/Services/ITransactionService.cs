using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Contracts.Requests;
using Wallet.Contracts.Responses;

namespace Wallet.UI.Services
{
    public interface ITransactionService
    {
        Task<bool> CreateAsync(TransactionRequest request);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<TransactionResponse>> GetAsync();

        Task<TransactionResponse> GetAsync(int id);

        Task<bool> UpdateAsync(int id, TransactionRequest request);
    }
}
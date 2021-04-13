using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Contracts.Requests;
using Wallet.Contracts.Responses;

namespace Wallet.UI.Services
{
    public class DummyTransactionService : ITransactionService
    {
        private int _id = 0;
        private List<TransactionResponse> _transactions = new List<TransactionResponse>();

        public Task<bool> CreateAsync(TransactionRequest request)
        {
            _transactions.Add(ToResponse(request));
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var transaction = _transactions.First(t => t.Id == id);
            return Task.FromResult(_transactions.Remove(transaction));
        }

        public Task<IEnumerable<TransactionResponse>> GetAsync() => Task.FromResult<IEnumerable<TransactionResponse>>(_transactions);

        public Task<TransactionResponse> GetAsync(int id) => Task.FromResult(_transactions.First(t => t.Id == id));

        public Task<bool> UpdateAsync(int id, TransactionRequest request)
        {
            var index = _transactions.FindIndex(t => t.Id == id);
            _transactions[index] = ToResponse(request);

            return Task.FromResult(true);
        }

        private TransactionResponse ToResponse(TransactionRequest request)
        {
            return new TransactionResponse
            {
                BankAmount = request.BankAmount,
                CashAmount = request.CashAmount,
                CategoryId = request.CategoryId,
                Comment = request.Comment,
                Date = request.Date,
                Id = _id++,
                Name = request.Name,
                SumAmount = request.BankAmount + request.CashAmount,
                Type = request.Type,
            };
        }
    }
}
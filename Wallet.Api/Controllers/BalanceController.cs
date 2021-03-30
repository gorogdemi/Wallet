using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wallet.Api.Context;
using Wallet.Api.Domain;
using Wallet.Contracts.Responses;

namespace Wallet.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class BalanceController : ControllerBase
    {
        private readonly WalletContext _walletContext;

        public BalanceController(WalletContext walletContext)
        {
            _walletContext = walletContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var expenses = await _walletContext.Transactions.Where(x => x.Type == TransactionType.Expense).SumAsync(x => x.Amount);
            var incomes = await _walletContext.Transactions.Where(x => x.Type == TransactionType.Income).SumAsync(x => x.Amount);

            return Ok(new BalanceResponse
            {
                Full = incomes - expenses,
                Cash = incomes - expenses,
                BankAccount = 0
            });
        }
    }
}
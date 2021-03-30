using System.Linq;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wallet.Api.Context;

namespace Wallet.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly WalletContext _walletContext;

        public TransactionController(ILogger<TransactionController> logger, WalletContext walletContext)
        {
            _logger = logger;
            _walletContext = walletContext;
        }

        [HttpGet]
        public Balance Get()
        {
            var expenses = _walletContext.Transactions.Where(x => x.Type == TransactionType.Expense).Sum(x => x.Amount);
            var incomes = _walletContext.Transactions.Where(x => x.Type == TransactionType.Income).Sum(x => x.Amount);

            return new Balance
            {
                Full = incomes - expenses,
                Cash = incomes - expenses,
                BankAccount = 0
            };
        }
    }
}
using System;
using System.Collections.Generic;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wallet.Api.Context;

namespace Wallet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly ILogger<IncomeController> _logger;
        private readonly WalletContext _walletContext;

        public IncomeController(ILogger<IncomeController> logger, WalletContext walletContext)
        {
            _logger = logger;
            _walletContext = walletContext;
        }

        [HttpGet]
        public IEnumerable<Income> Get()
        {
            _walletContext.Incomes.Add(new Income
            {
                Name = "Árvíztűrőtükörfúrógép",
                Amount = 1235.45,
                Date = DateTime.Now,
                Comment = "Ez egy teszt komment."
            });
            _walletContext.SaveChanges();
            return _walletContext.Incomes;
        }
    }
}
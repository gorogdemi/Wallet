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
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] _summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WalletContext _walletContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WalletContext walletContext)
        {
            _logger = logger;
            _walletContext = walletContext;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = _summaries[rng.Next(_summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet]
        public IEnumerable<Income> Get()
        {
            _walletContext.Incomes.Add(new Income
            {
                Name = "Adam",
                Amount = 1235.45,
                Date = DateTime.Now,
                Comment = "Ez egy teszt"
            });
            _walletContext.SaveChanges();
            return _walletContext.Incomes;
        }
    }
}
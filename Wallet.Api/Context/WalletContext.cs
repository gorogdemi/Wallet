using Domain;
using Microsoft.EntityFrameworkCore;

namespace Wallet.Api.Context
{
    public class WalletContext : DbContext
    {
        public virtual DbSet<Income> Incomes { get; set; }

        public WalletContext(DbContextOptions<WalletContext> options) : base(options)
        {
        }
    }
}
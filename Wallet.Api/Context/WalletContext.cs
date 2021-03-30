using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wallet.Api.Domain;

namespace Wallet.Api.Context
{
    public class WalletContext : IdentityDbContext<User>
    {
        public virtual DbSet<Transaction> Transactions { get; set; }

        public WalletContext(DbContextOptions<WalletContext> options) : base(options)
        {
        }
    }
}
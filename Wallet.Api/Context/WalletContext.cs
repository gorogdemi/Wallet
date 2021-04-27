﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wallet.Api.Domain;

namespace Wallet.Api.Context
{
    public class WalletContext : IdentityDbContext<User>
    {
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Transaction> Transactions { get; set; }

        public WalletContext(DbContextOptions<WalletContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Transaction>()
                 .HasOne(x => x.Category)
                 .WithMany(x => x.Transactions)
                 .HasForeignKey(x => x.CategoryId)
                 .OnDelete(DeleteBehavior.SetNull);

            modelBuilder
                 .Entity<Transaction>()
                 .HasOne(x => x.User)
                 .WithMany(x => x.Transactions)
                 .HasForeignKey(x => x.UserId)
                 .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
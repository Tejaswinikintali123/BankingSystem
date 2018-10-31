using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    class BankModel : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void 
            OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Bank;Integrated Security=True;Connect Timeout=30;");

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                .HasName("PK_Accounts");
                entity.Property(x => x.AccountNumber).ValueGeneratedOnAdd();
                entity.Property(x => x.Balance).IsRequired();
                entity.Property(x => x.EmailAddress).IsRequired().HasMaxLength(50);
            });
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                .HasName("PK_Transactions");
                entity.Property(x => x.TransactionId).ValueGeneratedOnAdd();
               
            });
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank

{
    public static class BankFactory
    {
        private static BankModel db = new BankModel();
        /// <summary>
        /// create account with the bank
        /// </summary>
        /// <param name="emailId">Email Address of the account</param>
        /// <param name="accountType">Type of account</param>
        /// <param name="initialamount">Initial deposit</param>
        /// <returns>newly created account</returns>
        /// <exception cref="ArgumentNullException"/>
        public static Account CreateAccount(string emailId, TypeofAccount accounttype=TypeofAccount.checking, decimal initialamount=0)
        {
            if (String.IsNullOrEmpty(emailId))
            {
                throw new ArgumentNullException(nameof(emailId), "Email address is required");
            }
            if(!IsValidEmail(emailId))
            {
                throw new FormatException("Email address is invalid");
            }
            var account = new Account
            {
                EmailAddress = emailId,
                AccountType = accounttype
            };
            if (initialamount > 0)
            {
                account.Deposit(initialamount);
            }
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;

        }
        public static void Deposit(int accountnumber,decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountnumber);
            account?.Deposit(amount);
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TypeOfTransaction = TransactionType.Credit,
                Description = "Bank deposit",
                Amount = amount,
                AccountNumber=accountnumber



            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
        public static void Withdraw(int accountnumber, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountnumber);
            if (account == null)
            {
                return;
            }
            account.Withdraw(amount);
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TypeOfTransaction = TransactionType.Debit,
                Description = "Bank withdrawal",
                Amount = amount,
                AccountNumber=accountnumber



            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
        public static IEnumerable<Account> GetAllAccounts(string emailAddress)
        {
            return db.Accounts.Where(a=>a.EmailAddress==emailAddress);
        }
        public static IEnumerable<Transaction> GetAllTransactions(int accountNo)
        {
           return db.Transactions.Where(t => t.AccountNumber == accountNo).OrderByDescending(t => t.TransactionDate);
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
            public static Account GetAccountDetails(int accountNo)
        {

            return db.Accounts.SingleOrDefault(m => m.AccountNumber == accountNo);
        }
        public static void EditAccount(Account updatedAccount)
        {
            var oldAccount = BankFactory.GetAccountDetails(updatedAccount.AccountNumber);
            oldAccount.EmailAddress= updatedAccount.EmailAddress;
            oldAccount.AccountType = updatedAccount.AccountType;
            db.Update(oldAccount);
            db.SaveChanges();

        }
        public static void DeleteAccount(int accountNo)
        {
            var account = BankFactory.GetAccountDetails(accountNo);
            db.Accounts.Remove(account);
            db.SaveChanges();
        }
        public static bool AccountExists(int id)
        {
            return db.Accounts.Any(e => e.AccountNumber == id);
        }
    }

}
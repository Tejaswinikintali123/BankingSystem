using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank

{
    static class Bank
    {
        private static List<Account> accounts = new List<Account>();
        /// <summary>
        /// create account with the bank
        /// </summary>
        /// <param name="emailAdress"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static Account CreateAccount(string emailAdress, TypeofAccount accounttype=TypeofAccount.checking, decimal initialamount=0)
        {
            var account = new Account
            {
                EmailAddress = emailAdress,
                AccountType = accounttype
            };
            if (initialamount > 0)
            {
                account.Deposit(initialamount);
            }
            accounts.Add(account);
            return account;

        }
        public static void Deposit(int accountnumber,decimal amount)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountnumber);
            account?.Deposit(amount);
        }
        public static void Withdraw(int accountnumber, decimal amount)
        {
            var account = accounts.SingleOrDefault(a => a.AccountNumber == accountnumber);
            if (account == null)
            {
                return;
            }
            account.Withdraw(amount);
        }
        public static IEnumerable<Account> GetAllAccounts()
        {
            return accounts;
        }
    }
}
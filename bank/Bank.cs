using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank

{
    static class Bank
    {
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
            return account;

        }
    }
}
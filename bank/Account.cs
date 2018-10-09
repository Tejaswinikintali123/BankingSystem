using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    enum TypeofAccount
    {
        savings,
        checking,
        cd,
        Loan
    }
    class Account
    {
        private static int lastAccountNumber = 0;

        #region properties
        /// <summary>
        /// Account number for account
        /// </summary>
        public int AccountNumber { get; }
        public TypeofAccount AccountType { get; set; }
        public Decimal Balance { get; private set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get;  }
        #endregion

        #region constructor
        public Account()
        {
            AccountNumber = ++lastAccountNumber;
            CreatedDate = DateTime.Now;
        }
         #endregion
        #region Methods
        /// <summary>
        /// deposit money into account
        /// </summary>
        /// <param name="amount">amount to deposit</param>
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
     
        #endregion


    }

   
}

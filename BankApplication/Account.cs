using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public enum TypeofAccount
    {
        savings,
        checking,
        cd,
        Loan
    }
    public class Account
    {
        

        #region properties
        /// <summary>
        /// Account number for account
        /// </summary>
        public int AccountNumber { get; set; }
        public TypeofAccount AccountType { get; set; }
        public Decimal Balance { get; private set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection <Transaction> Transactions { get; set; }
        #endregion

        #region constructor
        public Account()
        {
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
            if(amount > Balance)
            {
                throw new NSFException("ErrorCode:101", "Insufficient funds.");
            }
            Balance -= amount;
        }

        #endregion
        

    }

   
}

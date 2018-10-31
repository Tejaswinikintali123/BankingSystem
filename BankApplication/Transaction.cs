using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{public enum TransactionType

    {
        Credit,
        Debit
    }
    class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TypeOfTransaction{ get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bank
{
    public enum TransactionType

    {
        Credit,
        Debit
    }
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TypeOfTransaction{ get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("Account")]
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }



    }
}

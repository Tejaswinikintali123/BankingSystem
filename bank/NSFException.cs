using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class NSFException: Exception
    {
        public NSFException():base("not sufficient fund!")
        {

        }
        public NSFException(string errorCode, string message) : base(string.Format("{0} - {1}", errorCode, message))
        {

        }
    }
}

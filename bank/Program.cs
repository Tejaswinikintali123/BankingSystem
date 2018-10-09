using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcme to my bank");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.create an accout");
            Console.WriteLine("2.deposit");
            Console.WriteLine("3.withdraw");
            Console.WriteLine("4.print all accounts");
            Console.Write("please select an option:");
            var option= Console.ReadLine();
            switch (option)
            {
                case "0":
                    return;
                case "1":
                    Console.WriteLine("enter email adress");
                    var EmailAddress = Console.ReadLine();
                    var accounttypes = Enum.GetNames(typeof(TypeofAccount));
                    for (var i = 0; i < accounttypes.Length; i++)
                    {
                        Console.WriteLine("{0}.{1}", (i+1), accounttypes[i]);
                    }
                    Console.Write("select accounttype:");
                   var accounttypeoption= Console.ReadLine();
                    break;
                case "2":


                    break;







            
            }



        }
    }
}
﻿using System;
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
            int accountNo = 0;
            decimal amount = 0;
            Console.WriteLine("Welcme to my bank");
            while (true)
            {
                Console.WriteLine("0.Exit");
                Console.WriteLine("1.create an accout");
                Console.WriteLine("2.deposit");
                Console.WriteLine("3.withdraw");
                Console.WriteLine("4.print all accounts");
                Console.Write("please select an option:");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        return;
                    case "1":
                        try
                        {
                            Console.WriteLine("enter email adress");
                            var EmailAddress = Console.ReadLine();
                            var accounttypes = Enum.GetNames(typeof(TypeofAccount));
                            for (var i = 0; i < accounttypes.Length; i++)
                            {
                                Console.WriteLine("{0}.{1}", (i + 1), accounttypes[i]);
                            }
                            Console.Write("select accounttype:");
                            var accounttypeoption = Convert.ToInt32(Console.ReadLine());
                            var accountType = (TypeofAccount)Enum.Parse(typeof(TypeofAccount), accounttypes[accounttypeoption - 1]);
                            Console.Write("Amount to deposit: ");
                            var initialdeposit = Convert.ToDecimal(Console.ReadLine());
                            var account = Bank.CreateAccount(EmailAddress, accountType, initialdeposit);
                            Console.WriteLine($"AN:{ account.AccountNumber},AT: { account.AccountType},Balance:{account.Balance}");
                        }
                        catch(FormatException fx)
                        {
                            Console.WriteLine($"Error:{fx.Message}");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Incorrect account type.please try again");
                        }
                        catch(ArgumentNullException ax)
                        {
                            Console.WriteLine($"Error:{ax.Message}");
                        }
                        catch
                        {
                            Console.WriteLine("something went wrong:try again");
                        }
                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("enter account no.");
                        accountNo = Convert.ToInt32(Console.ReadLine());
                        Console.Write("enter amount to deposit: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNo, amount);

                        break;
                    case "3":
                        PrintAllAccounts();
                        Console.Write("enter account no.");
                        accountNo = Convert.ToInt32(Console.ReadLine());
                        Console.Write("enter amount to withdraw: ");
                        amount = Convert.ToDecimal(Console.ReadLine());
                        try
                        {
                            Bank.Withdraw(accountNo, amount);
                        }
                        catch(NSFException ex)
                        {
                            Console.Write(ex.Message);
                        }
                        
                        break;          
                    case "4":
                        PrintAllAccounts();

                        break;


                    default:
                        break;
                }
            }
        }

        private static void PrintAllAccounts()
        {
            var accounts = Bank.GetAllAccounts();
            foreach (var acnt in accounts)
            {
                Console.WriteLine($"AN:{acnt.AccountNumber},AT: { acnt.AccountType},Balance:{acnt.Balance}");
            }
        }
    }
}
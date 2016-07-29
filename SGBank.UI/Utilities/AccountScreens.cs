using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.UI.Utilities
{
    public static class AccountScreens
    {
        public static void PrintAccountDetails(Account account)
        {
            Console.WriteLine("Account Information");
            Console.WriteLine("===============================");
            Console.WriteLine($"Account Number {account.AccountNumber}");
            Console.WriteLine($"Name {account.FirstName} {account.LastName}");
            Console.WriteLine($"Account Balance {account.Balance:c}");   //q
        }

        public static void WorkflowErrorScreen(string message)
        {
            Console.Clear();
            Console.WriteLine("An error occured. {0}", message);
            UserPrompts.PressKeyForContinue();
        }

        public static void DepositDetails(DepositReciept reciept)
        {
            Console.Clear();
            Console.WriteLine("Deposited {0:c} to account {1}.", 
                reciept.DepositAmount,
                reciept.AccountNumber);
            Console.WriteLine("New Balance is {0}", reciept.NewBalance);
            UserPrompts.PressKeyForContinue();
        }

        public static void WithdrawDetails(WithdrawReceipt receipt)
        {
            Console.Clear();
            Console.WriteLine("Withdrawal {0} from account {1}",
                receipt.WithdrawAmount,
                receipt.AccountNumber);
            Console.WriteLine("New Balnace is {0}", receipt.NewBalance);
            UserPrompts.PressKeyForContinue();
        }
    }
}

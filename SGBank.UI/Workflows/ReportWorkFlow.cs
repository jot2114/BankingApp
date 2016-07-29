using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.UI.Utilities;

namespace SGBank.UI.Workflows
{
    public class ReportWorkFlow
    {
        AccountManager manager= new AccountManager();
        public void Execute()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Reports");
                Console.WriteLine("====================================");
                Console.WriteLine("\n1. Find the number of accounts");
                Console.WriteLine("2. Total amount in the bank");
                Console.WriteLine("3. Maximum balance ");
                Console.WriteLine("4. Minimum balance ");
                Console.WriteLine("\n(Q) to Quit");

                string input = UserPrompts.GetStringFromUser("\nEnter Choice: ");

                if (input.Substring(0, 1).ToUpper() == "Q")
                    break;

                ProcessChoice(input);

            } while (true);
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Total number of accounts are: {0}",manager.CountAccounts());
                    UserPrompts.PressKeyForContinue();
                    break;
                case "2":
                    Console.WriteLine("MAximum amount in the accounts:{0}",manager.MaxAmount());
                    UserPrompts.PressKeyForContinue();
                    break;
                case "3":
                    Console.WriteLine("Minimum amount in the accounts:{0}",manager.MinAmount());
                    UserPrompts.PressKeyForContinue();
                    break;
                case "4":
                    Console.WriteLine("Total amount in the accounts:{0}",manager.TotalAmount());
                    UserPrompts.PressKeyForContinue();
                    break;

            }
        }
    }
}

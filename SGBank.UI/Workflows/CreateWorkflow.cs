using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;
using SGBank.UI.Utilities;

namespace SGBank.UI.Workflows
{
    public class CreateWorkflow
    {
        public void Execute()
        {
            Account newAccount = new Account();    //newAccount for creating new account
            var manager = new AccountManager();
            newAccount.AccountNumber = UserPrompts.GetIntFromUser("Enter the Account Number for new user");
            newAccount.FirstName = UserPrompts.GetStringFromUser("Enter the first name of the acccount holder");
            newAccount.LastName = UserPrompts.GetStringFromUser("Enter the last name of the account holder");
            newAccount.Balance = UserPrompts.GetDecimalFromUser("Enter the starting balance you want to deposit");

            Console.WriteLine(manager.AddAccount(newAccount).Message);
            UserPrompts.PressKeyForContinue();
        }


    }
}

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
    class DeleteWorkflow
    {
        public void Execute()
        {
            var manager = new AccountManager();
            int DeletedAccount= UserPrompts.GetIntFromUser("Enter the account number you want to delete");
               
           Console.WriteLine(manager.DeleteAccount(DeletedAccount).Message);
            UserPrompts.PressKeyForContinue();        
        }
    }
}

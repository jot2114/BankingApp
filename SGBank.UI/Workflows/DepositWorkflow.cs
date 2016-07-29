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
    public class DepositWorkflow
    {
        public void Execute(Account account)
        {
            decimal amount = UserPrompts.GetDecimalFromUser("Please provide a deposit amount:");
            Deposit(account, amount);
        }

        public void Deposit(Account account, decimal amount)
        {
            var manager = new AccountManager();
            var response = manager.Deposit(amount, account);

            if (response.Success)
            {
                AccountScreens.DepositDetails(response.Data);
            }
            else
            {
                AccountScreens.WorkflowErrorScreen(response.Message);
            }
        }
    }
}

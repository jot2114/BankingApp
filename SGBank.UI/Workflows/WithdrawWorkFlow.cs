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
    public class WithdrawWorkFlow
    {
        public void Execute(Account account)
        {
            decimal amount = UserPrompts.GetDecimalFromUser(" Please enter the amount you want to withhdraw");
            Withdraw(account,amount);
        }

        public Response<WithdrawReceipt> Withdraw(Account account, decimal amount)
        {
            var manager = new AccountManager();
            var response = manager.withdraw(amount, account);
            if (response.Success)
            {
                AccountScreens.WithdrawDetails(response.Data);
            }
            else
            {
                AccountScreens.WorkflowErrorScreen(response.Message);
            }
            return response;
        }
    }
}

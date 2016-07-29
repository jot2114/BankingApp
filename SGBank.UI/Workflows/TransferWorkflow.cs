using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;
using SGBank.UI.Utilities;

namespace SGBank.UI.Workflows
{
    public class TransferWorkflow
    {
        public void Execute(Account CurrentAccount)
        {
            int accountNumber = UserPrompts.GetIntFromUser("Enter the account number in which you want to transfer money");
            var manager = new AccountManager();
            var TransferAccount = manager.GetAccount(accountNumber).Data;  //q

            decimal amount = UserPrompts.GetDecimalFromUser("Please provide the amount you want to transfer");
            
            WithdrawWorkFlow withdraw = new WithdrawWorkFlow();
            DepositWorkflow deposit = new DepositWorkflow();

            if( withdraw.Withdraw(CurrentAccount, amount).Success)
                deposit.Deposit(TransferAccount, amount);

        }
    }
}

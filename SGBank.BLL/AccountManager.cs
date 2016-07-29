using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.BLL
{
    public class AccountManager
    {
        public Response<Account> GetAccount(int accountNumber)
        {
            var repo = new AccountRepository(); // we are in BLL, creating objects for Data and Models.
            var result = new Response<Account>();

            try
            {
                var account = repo.LoadAccount(accountNumber);

                if (account == null)
                {
                    result.Success = false;
                    result.Message = "Account was not found.";
                }
                else
                {
                    result.Success = true;
                    result.Data = account;
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "There was an error. Please try again later.";
                //log.logError(ex.Message);
            }

            return result;
        }

        public Response<DepositReciept> Deposit(decimal amount, Account account)
        {
            var response = new Response<DepositReciept>();
            //var x = new Response<AccountManager>();
            try
            {
                if (amount <= 0)
                {
                    response.Success = false;
                    response.Message = "Must provide a positive value.";
                }
                else
                {
                    account.Balance += amount;

                    var repo = new AccountRepository();
                    repo.UpdateAccount(account);

                    response.Success = true;
                    response.Data = new DepositReciept();     //q
                    response.Data.AccountNumber = account.AccountNumber;
                    response.Data.DepositAmount = amount;
                    response.Data.NewBalance = account.Balance;
                    //  x.Data.AddAccount()
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Account is no longer valid.";
                //log.logError(ex.Message);
            }
            return response;
        }

        public Response<WithdrawReceipt> withdraw(decimal amount, Account account)
        {
            var response = new Response<WithdrawReceipt>();

            try
            {
                if (amount <= account.Balance)
                {
                    account.Balance -= amount;
                    var repo = new AccountRepository();
                    repo.UpdateAccount(account);

                    response.Success = true;
                    response.Data = new WithdrawReceipt();
                    response.Data.AccountNumber = account.AccountNumber;
                    response.Data.WithdrawAmount = amount;
                    response.Data.NewBalance = account.Balance;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Requested Data is not available in your account";
                }
            }
            catch (Exception)
            {
                {
                    response.Success = false;
                    response.Message = " Account doesnot exit";
                }

            }
            return response;
        }

        public Response<Account> AddAccount(Account NewAccount)
        {
            var repo = new AccountRepository();
            var result = new Response<Account>();
            try
            {
                var account = repo.LoadAccount(NewAccount.AccountNumber);
                if (account == null)
                {
                    result.Success = true;
                    result.Message = " Account has been created";
                    //addaccount
                    repo.AddAccount(NewAccount);
                }
                else
                {
                    result.Success = false;
                    result.Message = "Already existes, so Account cannot be created";
                }

            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "There was an error. Please try again later.";
            }
            return result;
        }

        public Response<Account> DeleteAccount(int AccountNumber)
        {
            var repo = new AccountRepository();
            var result = new Response<Account>();
            try
            {
                var account = repo.LoadAccount(AccountNumber);
                if (account == null)
                {
                    result.Success = false;
                    result.Message = " Account doesnot exist, so it couldnot be deleted";

                }
                else if (account.Balance != 0)
                {
                    result.Success = false;
                    result.Message = "Balance should be zero";
                }
                else
                {
                    result.Success = true;
                    result.Message = "Account deleted";
                    repo.DeleteAccount(AccountNumber);
                }

            }
            catch (Exception)
            {

            }
            return result;
        }

        public int CountAccounts()
        {
            var repo = new AccountRepository();
            var result = new Response<Account>();

            int count = repo.GetAllAccounts().Count;
            return count;
        }

        public decimal MaxAmount()
        {
            var repo = new AccountRepository();

            var accounts = repo.GetAllAccounts();
            decimal result = accounts.Max(a => a.Balance);
            return result;
        }

        public decimal MinAmount()
        {
            var repo = new AccountRepository();

            var accounts = repo.GetAllAccounts();
            decimal result = accounts.Min(a => a.Balance);
            return result;
        }

        public decimal TotalAmount()
        {
            var repo = new AccountRepository();

            var accounts = repo.GetAllAccounts();
            decimal result = accounts.Sum(a => a.Balance);
            return result;
        }
    }

 }

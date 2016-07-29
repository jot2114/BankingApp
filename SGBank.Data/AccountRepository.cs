using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;   // for adding File
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.Data
{
    public class AccountRepository
    {
        private const string _filePath = @"DataFiles\Bank.txt";  

        public List<Account> GetAllAccounts()        //you want to fetch all accounts
        {
            List<Account> results = new List<Account>();

            var rows = File.ReadAllLines(_filePath);   //gives an array of all lines in the file.

            for (int i = 1; i < rows.Length; i++)  // starting from 1 bcoz we are akipping the header
            {
                var columns = rows[i].Split(',');
 
                var account = new Account();   //we are in data, so creating object for Models
                    
                                           //var gives an error if we add string and integer
                account.AccountNumber = int.Parse(columns[0]);   // inserting values in Account variables
               // account.AccountNumber = i;
                account.FirstName = columns[1];
                account.LastName = columns[2];
                account.Balance = decimal.Parse(columns[3]);

                results.Add(account);  //adding to the list
            }
            return results;
        }

        public Account LoadAccount(int accountNumber)    // it returns a single account number based on the account number I have passed
        {
            List<Account> accounts = GetAllAccounts();
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public void UpdateAccount(Account account)
        {
            var accounts = GetAllAccounts();

            var accountToUpdate = accounts
                .First(a => a.AccountNumber == account.AccountNumber);

            accountToUpdate.FirstName = account.FirstName;
            accountToUpdate.LastName = account.LastName;
            accountToUpdate.Balance = account.Balance;

            OverwriteFile(accounts);
        }

        private void OverwriteFile(List<Account> accounts)  // it allows everytime to save the data
        {
            File.Delete(_filePath);

            using (var writer = File.CreateText(_filePath))
            {
                writer.WriteLine("AccountNumber,FirstName,LastName,Balance");
                foreach (var account in accounts)
                {
                    writer.WriteLine("{0},{1},{2},{3}",
                        account.AccountNumber,
                        account.FirstName,
                        account.LastName,
                        account.Balance);
                }
            }
        }

        public void AddAccount(Account account)
        {
            using (var writer = File.AppendText(_filePath))
            {
                writer.WriteLine("{0},{1},{2},{3}",
                    account.AccountNumber,
                    account.FirstName,
                    account.LastName,
                    account.Balance);
            }              
        }

        public void DeleteAccount(int AccountNumber)
        {
            var accounts = GetAllAccounts();
            var result = accounts.Where(a => a.AccountNumber != AccountNumber);
            OverwriteFile(result.ToList());
        }
    }
}

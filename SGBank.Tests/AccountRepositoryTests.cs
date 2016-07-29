using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.Data;

namespace SGBank.Tests
{
    [TestFixture]
    public class AccountRepositoryTests
    {
        [Test]
        public void CanLoadAllAccounts()
        {
            var repo = new AccountRepository();
            var accounts = repo.GetAllAccounts();

            Assert.AreEqual(4,accounts.Count);
        }

        [TestCase(1, "Mary")]
        [TestCase(2, "Bob")]
        public void CanLoadSpecificAccount(int accountNumber, string expected)
        {
            var repo = new AccountRepository();
            var account = repo.LoadAccount(accountNumber);

            Assert.AreEqual(expected, account.FirstName);
        }

        [Test]
        public void UpdateAccountSucceeds()
        {
            var repo = new AccountRepository();
            var accountToUpdate = repo.LoadAccount(1);
            accountToUpdate.Balance = 500.00m;
            repo.UpdateAccount(accountToUpdate);

            var result = repo.LoadAccount(1);
            Assert.AreEqual(500.00m, result.Balance);
        }      
     }
 }

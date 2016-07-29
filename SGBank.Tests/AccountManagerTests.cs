using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.Tests
{
    [TestFixture]
    public class AccountManagerTests
    {

        [Test]
        public void FoundAccountReturnsSuccess()
        {
            var manager = new AccountManager();
            var response = manager.GetAccount(1);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Data.AccountNumber);
            Assert.AreEqual("Mary", response.Data.FirstName);
        }

        [Test]
        public void NotFoundAccountReturnsFail()
        {
            var manager = new AccountManager();
            var response = manager.GetAccount(9999);
            Assert.IsFalse(response.Success);
        }

        ////[Test]
        ////public void DepositReturnsSuccess()
        ////{
        ////    var manager = new AccountManager();
        ////    Account account = manager.GetAccount(1).Data;
        ////    var response = manager.Deposit(20, account);
        ////    Assert.IsTrue(response.Success);
        //}

        [Test]
        public void DepositReturnsFail()
        {
            var manager = new AccountManager();
            Account account = manager.GetAccount(1).Data;
            var response = manager.Deposit(-20, account);
            Assert.IsTrue(!response.Success);
        }

        [TestCase(20,true)]
        [TestCase(-100,false)]
        public void DepositReturnsSuccess(decimal amount, bool invalid)
        {
            var manager = new AccountManager();
            Account account = manager.GetAccount(1).Data;
            var response = manager.Deposit(amount, account);
            Assert.AreEqual(invalid, response.Success);
        }

        [TestCase(10000000, false)]
        [TestCase(1, true)]
        public void WithdrawSuccess(decimal amount, bool invalid)
        {
            var manager = new AccountManager();
            Account account = manager.GetAccount(1).Data;
            var response = manager.withdraw(amount, account);
            Assert.AreEqual(invalid, response.Success);
        }

        [TestCase(1, false)]
        [TestCase(10, true)]
        public void AddAccountSuccess(int accountNumber, bool invalid)
        {
            var manager = new AccountManager();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            var response = manager.AddAccount(account);
            Assert.AreEqual(invalid, response.Success);
        }

        [TestCase(10, false)]
        [TestCase(2, true)]
        public void DeleteAccountSuccess(int accountNumber, bool invalid)
        {
            var manager = new AccountManager();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            var response = manager.DeleteAccount(accountNumber);
            Assert.AreEqual(invalid, response.Success);
        }

    }
}

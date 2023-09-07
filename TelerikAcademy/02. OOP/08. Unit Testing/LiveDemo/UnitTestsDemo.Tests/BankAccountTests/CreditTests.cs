using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestsDemo.Models;

namespace UnitTestsDemo.Tests.BankAccountTests
{
    [TestClass]
    public class CreditTests
    {


        [TestMethod]
        public void CreditShouldAdd_When_InputIsValid()
        {
            //Arrange
            var ownerName = "ValidName";
            var balance = 7;
            var bankAccount = new BankAccount(ownerName, balance);
            var ammountToDebit = 93;
            var expectedBalance = balance + ammountToDebit;

            //Act
            bankAccount.Credit(ammountToDebit);
            //Assert
            Assert.AreEqual(expectedBalance, bankAccount.Balance,"Actual balance is different from expected");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreditShouldThrow_When_AmountIsNegative()
        {
            //Arrange
            var ownerName = "validName";
            double balance = 0;

            var bankAccount = new BankAccount(ownerName, balance);
            var ammountToCredit = -20;
            //Act & Assert
            bankAccount.Credit(ammountToCredit);
        }
    }
}

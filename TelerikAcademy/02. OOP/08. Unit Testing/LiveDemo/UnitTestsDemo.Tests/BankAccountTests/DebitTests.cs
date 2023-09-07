using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestsDemo.Models;

namespace UnitTestsDemo.Tests.BankAccountTests
{
    [TestClass]
    public class DebitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DebitShouldThrow_When_AmountIsGreaterThanCurrentBalance()
        {
            //Arrange
            var owner = "ValidName";
            double balance = 50;
            double amountToDebit = 100;
            var bankAccount = new BankAccount(owner, balance);
            //Act&Assert
            bankAccount.Debit(amountToDebit);


        }
        [TestMethod]
        public void DebitShould_SubstractCorrectAmountFromAccountBalance()
        {
            //Arrange
            var owner = "ValidName";
            double balance = 50;
            double amountToDebit = 50;
            double expectedAmount = balance - amountToDebit;

            var bankAccount = new BankAccount(owner, balance);
            //Act
            bankAccount.Debit(amountToDebit);
            //Assert
            Assert.IsTrue(expectedAmount == bankAccount.Balance, "Actual balance is different from expected");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DebitShouldThrow_When_AmmountIsNegative()
        {
            //Arrange
            var owner = "ValidName";
            double balance = 50;
            double amountToDebit = -10;
            var bankAccount = new BankAccount(owner, balance);
            //Act & Assert
            bankAccount.Debit(amountToDebit);
            
        }


    }
}

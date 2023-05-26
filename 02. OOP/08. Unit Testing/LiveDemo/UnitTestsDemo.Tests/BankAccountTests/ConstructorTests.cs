using UnitTestsDemo.Models;

namespace UnitTestsDemo.Tests.BankAccountTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void ConstructorShould_CreateBankAccount_When_StartingBalanceIsValid()
        {
            //Arrange
            double balance = 0;
            string ownerName = "ValidName";

            //Act
            var bankAccount = new BankAccount(ownerName, balance);

            //Assert
            Assert.AreEqual(balance, bankAccount.Balance,"Balances are not equal");
        }

        [TestMethod]
        public void ConstructorShould_CreateBankAccount_When_CustomerNameIsValid()
        {
            //Arrange
            double balance = 0;
            string ownerName = "ValidName";

            //Act
            var bankAccount = new BankAccount(ownerName, balance);
            //Assert
            Assert.AreEqual(ownerName, bankAccount.CustomerName, "Names are not equal");
        }

        [TestMethod]
        public void ConstructorShould_CreateBankAccountOfCorrectType_When_ParametersAreValid()
        {
            //Arrange
            double balance = 0;
            string ownerName = "ValidName";

            //Act
            var bankAccount = new BankAccount(ownerName, balance);
            //Assert
            Assert.IsInstanceOfType(bankAccount, typeof(BankAccount), "Object is not of the expected type");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorShould_Throw_When_CustomerNameIsTooShort()
        {
            //Arrange
            double balance = 0;
            string ownerName = "X";

            //Act & Assert
            var bankAccount = new BankAccount(ownerName,balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorShould_Throw_When_CustomerNameIsTooLong()
        {
            //Arrange
            double balance = 0;
            string ownerName = new string('x', 20);

            //Act & Assert
            var bankAccount = new BankAccount(ownerName, balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorShould_Throw_When_BalanceIsNegative()
        {
            //Arrange
            double balance = -50;
            string ownerName = "ValidName";

            //Act & Assert
            var bankAccount = new BankAccount(ownerName, balance);
        }

    }
}
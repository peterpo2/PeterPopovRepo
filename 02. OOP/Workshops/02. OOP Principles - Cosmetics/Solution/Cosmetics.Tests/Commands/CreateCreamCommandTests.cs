using System;
using System.Collections.Generic;
using System.Linq;
using Cosmetics.Commands;
using Cosmetics.Commands.Contracts;
using Cosmetics.Core;
using Cosmetics.Core.Contracts;
using Cosmetics.Models.Enums;
using Cosmetics.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Cosmetics.Tests.Helpers.TestData;

namespace Cosmetics.Tests.Commands
{
    [TestClass]
    public class CreateCreamCommandTests
    {
        private readonly string[] CreateCreamParameters = new string[] 
        {
            CreamData.ValidName, CreamData.ValidBrand, "10.99", "Women", "Lavender" 
        };

        private IRepository repository;

        [TestInitialize]
        public void Setup()
        {
            repository = new Repository();
        }

        [TestMethod]
        [DataRow(CreateCreamCommand.ExpectedNumberOfArguments - 1)]
        [DataRow(CreateCreamCommand.ExpectedNumberOfArguments + 1)]
        public void Should_ThrowException_When_InvalidArgumentsCount(int testSize)
        {
            // Arrange
            ICommand command = new CreateCreamCommand(TestHelpers.InitializeListWithSize(testSize), repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_ThrowException_When_PriceInvalid()
        {
            // Arrange
            IList<string> commandParameters = new string[]
            {
                CreamData.ValidName,
                CreamData.ValidBrand,
                "Invalid Price",
                GenderType.Unisex.ToString(),
                ScentType.Lavender.ToString()
            }.ToList();

            ICommand command = new CreateCreamCommand(commandParameters, repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_ThrowException_When_GenderInvalid()
        {
            // Arrange
            IList<string> commandParameters = new string[]
            {
                CreamData.ValidName,
                CreamData.ValidBrand,
                "10",
                "Invalid Gender",
                ScentType.Lavender.ToString()
            }.ToList();

            ICommand command = new CreateCreamCommand(commandParameters, repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_ThrowException_When_ScentInvalid()
        {
            // Arrange
            IList<string> commandParameters = new string[]
            {
                CreamData.ValidName,
                CreamData.ValidBrand,
                "10",
                GenderType.Unisex.ToString(),
                "Invalid Scent"
            }.ToList();

            ICommand command = new CreateCreamCommand(commandParameters, repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_ThrowException_When_CreamNameExists()
        {
            // Arrange
            ICommand createCream = new CreateCreamCommand(CreateCreamParameters.ToList(), repository);
            createCream.Execute();

            ICommand createDuplicateCream = new CreateCreamCommand(CreateCreamParameters.ToList(), repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => createDuplicateCream.Execute());
        }

        [TestMethod]
        public void Should_AddCream_When_ArgumentsAreValid()
        {
            // Arrange
            ICommand createCream = new CreateCreamCommand(CreateCreamParameters.ToList(), repository);

            // Act
            createCream.Execute();

            // Assert
            Assert.AreEqual(1, repository.Products.Count);
        }
    }
}

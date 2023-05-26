using Cosmetics.Commands;
using Cosmetics.Commands.Contracts;
using Cosmetics.Core;
using Cosmetics.Core.Contracts;
using Cosmetics.Models.Enums;
using Cosmetics.Tests.Helpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

using static Cosmetics.Tests.Helpers.TestData;

namespace Cosmetics.Tests.Commands
{
    [TestClass]
    public class CreateToothpasteCommandTests
    {
        private readonly string[] CreateToothpasteParameters = new string[]
        {
            ToothpasteData.ValidName, ToothpasteData.ValidBrand, "10.99", "Men", "calcium,fluorid"
        };

        private IRepository repository;

        [TestInitialize]
        public void Setup()
        {
            repository = new Repository();
        }

        [TestMethod]
        [DataRow(CreateToothpasteCommand.ExpectedNumberOfArguments - 1)]
        [DataRow(CreateToothpasteCommand.ExpectedNumberOfArguments + 1)]
        public void Should_ThrowException_When_InvalidArgumentsCount(int testSize)
        {
            // Arrange
            ICommand command = new CreateToothpasteCommand(TestHelpers.InitializeListWithSize(testSize), repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }
        [TestMethod]
        public void Should_ThrowException_When_PriceInvalid()
        {
            // Arrange
            IList<string> commandParameters = new string[]
            {
                ToothpasteData.ValidName,
                ToothpasteData.ValidBrand,
                "Invalid Price",
                GenderType.Unisex.ToString(),
                "calcium,fluorid"
            }.ToList();

            ICommand command = new CreateToothpasteCommand(commandParameters, repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_ThrowException_When_GenderInvalid()
        {
            // Arrange
            IList<string> commandParameters = new string[]
            {
                ToothpasteData.ValidName,
                ToothpasteData.ValidBrand,
                "10",
                "Invalid Gender",
                "calcium,fluorid"
            }.ToList();

            ICommand command = new CreateToothpasteCommand(commandParameters, repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_ThrowException_When_ToothpasteNameExists()
        {
            // Arrange
            ICommand createToothpaste = new CreateToothpasteCommand(CreateToothpasteParameters.ToList(), repository);
            createToothpaste.Execute();

            ICommand createDuplicateToothpaste = new CreateToothpasteCommand(CreateToothpasteParameters.ToList(), repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => createDuplicateToothpaste.Execute());
        }

        [TestMethod]
        public void CreateToothpaste_Should_AddProduct_When_ArgumentsAreValid()
        {
            // Arrange
            ICommand createToothpaste = new CreateToothpasteCommand(CreateToothpasteParameters.ToList(), repository);

            // Act
            createToothpaste.Execute();

            // Assert
            Assert.AreEqual(1, repository.Products.Count);
        }
    }
}

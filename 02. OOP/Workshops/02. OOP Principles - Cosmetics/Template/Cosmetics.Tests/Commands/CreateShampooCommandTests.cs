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
    public class CreateShampooCommandTests
    {
        private readonly string[] CreateShampooParameters = new string[]
        {
            ShampooData.ValidName, ShampooData.ValidBrand, "10.99", "Men", "100", "EveryDay"
        };

        private IRepository repository;

        [TestInitialize]
        public void Setup()
        {
            repository = new Repository();
        }

        [TestMethod]
        [DataRow(CreateShampooCommand.ExpectedNumberOfArguments - 1)]
        [DataRow(CreateShampooCommand.ExpectedNumberOfArguments + 1)]
        public void Should_ThrowException_When_InvalidArgumentsCount(int testSize)
        {
            // Arrange
            ICommand command = new CreateShampooCommand(TestHelpers.InitializeListWithSize(testSize), repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }
        [TestMethod]
        public void Should_ThrowException_When_PriceInvalid()
        {
            // Arrange
            IList<string> commandParameters = new string[]
            {
                ShampooData.ValidName,
                ShampooData.ValidBrand,
                "Invalid Price",
                GenderType.Unisex.ToString(),
                "100",
                UsageType.EveryDay.ToString()
            }.ToList();

            ICommand command = new CreateShampooCommand(commandParameters, repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_ThrowException_When_GenderInvalid()
        {
            // Arrange
            IList<string> commandParameters = new string[]
            {
                ShampooData.ValidName,
                ShampooData.ValidBrand,
                "10",
                "Invalid Gender",
                "100",
                UsageType.EveryDay.ToString()
            }.ToList();

            ICommand command = new CreateShampooCommand(commandParameters, repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_ThrowException_When_UsageTypeInvalid()
        {
            // Arrange
            IList<string> commandParameters = new string[]
            {
                ShampooData.ValidName,
                ShampooData.ValidBrand,
                "10",
                GenderType.Unisex.ToString(),
                "100",
                "Invalid Usage Type"
            }.ToList();

            ICommand command = new CreateShampooCommand(commandParameters, repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_ThrowException_When_MillilitersInvalid()
        {
            // Arrange
            IList<string> commandParameters = new string[]
            {
                ShampooData.ValidName,
                ShampooData.ValidBrand,
                "10",
                GenderType.Unisex.ToString(),
                "Invalid Millilitres",
                UsageType.EveryDay.ToString()
            }.ToList();

            ICommand command = new CreateShampooCommand(commandParameters, repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void Should_ThrowException_When_ShampooNameExists()
        {
            // Arrange
            ICommand createShampoo = new CreateShampooCommand(CreateShampooParameters.ToList(), repository);
            createShampoo.Execute();

            ICommand createDuplicateShampoo = new CreateShampooCommand(CreateShampooParameters.ToList(), repository);

            // Act, Assert
            Assert.ThrowsException<ArgumentException>(() => createDuplicateShampoo.Execute());
        }

        [TestMethod]
        public void Should_AddProduct_When_ArgumentsAreValid()
        {
            // Arrange
            ICommand createShampoo = new CreateShampooCommand(CreateShampooParameters.ToList(), repository);

            // Act
            createShampoo.Execute();

            // Assert
            Assert.AreEqual(1, repository.Products.Count);
        }
    }
}

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;
using AspNetCoreDemo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreDemo.Tests.BeersServiceTests
{
    [TestClass]
    public class DeleteBeerShould
    {
        [TestMethod]
        public void ThrowsException_When_UserNotCreator()
        {
            User testUser = new User { Id = 1, Username = "TestUser", IsAdmin = false };
            User loggedUser = new User { Id = 2, Username = "LoggedUser", IsAdmin = false };
            Beer testBeer = new Beer
            {
                Id = 1,
                Abv = 5.0,
                Name = "TestBeer",
                StyleId = 1,
                CreatedBy = testUser,
                CreatedById = 1
            };

            var repositoryMock = new Mock<IBeersRepository>();

            repositoryMock.Setup(repo => repo
                .GetById(testBeer.Id))
                .Returns(testBeer);

            repositoryMock.Setup(repo => repo.Delete(testBeer.Id))
                .Returns(testBeer);

            var sut = new BeersService(repositoryMock.Object);

            Assert.ThrowsException<UnauthorizedOperationException>(() => sut.Delete(1, loggedUser));

        }
        [TestMethod]
        public void DeleteBeer_When_LoggedUserIsAdmin()
        {
            // Arrange
            User testUser = new User { Id = 1, Username = "TestUser", IsAdmin = false };
            User loggedUser = new User { Id = 2, Username = "LoggedUser", IsAdmin = true };
            Beer testBeer = new Beer
            {
                Id = 1,
                Abv = 5.0,
                Name = "TestBeer",
                StyleId = 1,
                CreatedBy = testUser,
                CreatedById = 1
            };

            var repositoryMock = new Mock<IBeersRepository>();

            repositoryMock.Setup(repo => repo
                .GetById(testBeer.Id))
                .Returns(testBeer);

            repositoryMock.Setup(repo => repo.Delete(testBeer.Id))
                .Returns(testBeer);

            var sut = new BeersService(repositoryMock.Object);

            // Act
            Beer actualBeer = sut.Delete(1, testUser);

            // Assert
            Assert.AreEqual(testBeer, actualBeer);

        }
    }
}

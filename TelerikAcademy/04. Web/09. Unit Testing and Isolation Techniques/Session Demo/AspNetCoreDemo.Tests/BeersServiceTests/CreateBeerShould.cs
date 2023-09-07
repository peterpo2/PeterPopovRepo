using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;
using AspNetCoreDemo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AspNetCoreDemo.Tests.BeersServiceTests
{
    [TestClass]
    public class CreateBeerShould
    {
        [TestMethod]
        public void ReturnCorrectBeer_When_ParamsAreValid()
        {
            //Arrange
            Beer testBeer = new Beer { Id = 1, Abv = 5.0, Name = "TestBeer", StyleId = 1, CreatedById = 1 };
            User testUser = new User { Id = 1, Username = "TestUser", IsAdmin = false };

            var repositoryMock = new Mock<IBeersRepository>();

            repositoryMock
                .Setup(repo => repo.Create(testBeer))
                .Returns(testBeer);

            var sut = new BeersService(repositoryMock.Object);

            //Act

            Beer actualBeer = sut.Create(testBeer, testUser);

            //Assert

            Assert.AreEqual(testBeer, actualBeer);
        }

        [TestMethod]
        public void Throw_When_ParamsAreInvalid()
        {

            //Arrange
            Beer testBeer = new Beer { Id = 1, Abv = 5.0, Name = "TestBeer", StyleId = 1, CreatedById = 1 };
            User testUser = new User { Id = 1, Username = "TestUser", IsAdmin = false };
            var repositoryMock = new Mock<IBeersRepository>();

            repositoryMock.Setup(repo => repo.BeerExists(It.IsAny<string>()))
                .Returns(true);

            var sut = new BeersService(repositoryMock.Object);

            //Act & Assert

            Assert.ThrowsException<DuplicateEntityException>(() => sut.Create(testBeer, testUser));


        }
    }
}

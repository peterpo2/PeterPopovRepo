using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;
using AspNetCoreDemo.Services;
using Moq;

namespace AspNetCoreDemo.Tests.BeersServiceTests
{
    [TestClass]
    public class GetBeerShould
    {
        [TestMethod]
        public void ReturnCorrectBeer_When_ParamsAreValid()
        {
            //Arrange

            Beer expectedBeer = new Beer { Id = 1, Abv = 5.0, Name = "TestBeer", StyleId = 1, CreatedById = 1 };

            var repositoryMock = new Mock<IBeersRepository>();

            repositoryMock
                .Setup(repo => repo.GetById(1))
                .Returns(expectedBeer);

            var sut = new BeersService(repositoryMock.Object);

            //Act

            Beer actualBeer = sut.GetById(expectedBeer.Id);

            //Assert
            Assert.AreEqual(expectedBeer, actualBeer);
        }

        [TestMethod]
        public void ThrowException_When_BeerNotFound()
        {
            //Arrange
            var repositoryMock = new Mock<IBeersRepository>();

            repositoryMock
                .Setup(repo => repo.GetById(It.IsAny<int>()))
                .Throws(new EntityNotFoundException("Beer doesn't exit"));

            var sut = new BeersService(repositoryMock.Object);
            //Act & Assert

            Assert.ThrowsException<EntityNotFoundException>(() => sut.GetById(It.IsAny<int>()));

        }
    }
}
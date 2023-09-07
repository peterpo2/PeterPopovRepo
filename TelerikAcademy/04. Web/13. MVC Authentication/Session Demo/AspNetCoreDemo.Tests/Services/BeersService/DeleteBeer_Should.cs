
using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories.Contracts;
using AspNetCoreDemo.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace AspNetCoreDemo.Tests.Services.Beers
{
    [TestClass]
	public class DeleteBeer_Should 
	{
		[TestMethod]
        public void ThrowException_When_BeerCreatedByUserMismatch()
        {
            // Arrange
            Beer testBeer = TestHelper.GetTestBeer();
            User testUser = TestHelper.GetTestUser();

            var repositoryMock = new Mock<IBeersRepository>();

            repositoryMock
                .Setup(repo => repo.GetById(It.IsAny<int>()))
                .Returns(testBeer);

            var sut = new BeersService(repositoryMock.Object);

            Assert.ThrowsException<UnauthorizedOperationException>(() => sut.Delete(testBeer.Id, testUser));
        }
    }
}

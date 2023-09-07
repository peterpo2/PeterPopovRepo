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
		public void ThrowException_When_UserNotCreator()
		{
			// Arrange
			var user = TestHelper.GetTestUser();
			var beer = TestHelper.GetTestBeer();
			
			var repositoryMock = new Mock<IBeersRepository>();

			repositoryMock
				.Setup(repo => repo.GetById(It.IsAny<int>()))
				.Returns(beer);

			repositoryMock
				.Setup(repo => repo.Delete(It.IsAny<int>()));

			var sut = new BeersService(repositoryMock.Object);
			
			Assert.ThrowsException<UnauthorizedOperationException>(() => sut.Delete(beer.Id, user));
		}
	}
}

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories.Contracts;
using AspNetCoreDemo.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace AspNetCoreDemo.Tests.Services.Beers
{
    [TestClass]
	public class CreateBeer_Should
	{
		[TestMethod]
		public void ReturnCorrectBeer_When_ParamsAreValid()
		{
			// Arrange        
			Beer testBeer = TestHelper.GetTestBeer();
			User testUser = TestHelper.GetTestUser();

			var repositoryMock = new Mock<IBeersRepository>();

			repositoryMock
				.Setup(repo => repo.GetByName(It.IsAny<string>()))
				.Throws(new EntityNotFoundException($"Beer doesn't exist."));

			repositoryMock
				.Setup(repo => repo.Create(It.IsAny<Beer>()))
				.Returns(testBeer);

			var sut = new BeersService(repositoryMock.Object);

			// Act
			Beer actualBeer = sut.Create(testBeer, testUser);

			// Assert
			Assert.AreEqual(testBeer.Id, actualBeer.Id);
			Assert.AreEqual(testBeer.Name, actualBeer.Name);
			Assert.AreEqual(testBeer.Abv, actualBeer.Abv);
			Assert.AreEqual(testBeer.CreatedById, actualBeer.CreatedById);
			Assert.AreEqual(testBeer.StyleId, actualBeer.StyleId);
		}
	}
}

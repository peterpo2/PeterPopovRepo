using System.Collections.Generic;
using System.Linq;

using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;
using AspNetCoreDemo.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace AspNetCoreDemo.Tests.Services.Beers
{
	[TestClass]
	public class GetBeer_Should 
	{
		[TestMethod]
		public void ReturnCorrectBeer_When_ParamsAreValid()
		{
			// Arrange        
			Beer expectedBeer = TestHelper.GetTestBeer();

			var repositoryMock = new Mock<IBeersRepository>();
			List<Beer> beers = TestHelper.GetTestBeers();

			repositoryMock
				.Setup(repo => repo.GetById(It.IsAny<int>()))
				.Returns<int>(id => beers.Where(b => b.Id == id).FirstOrDefault());

			var sut = new BeersService(repositoryMock.Object);

			// Act
			Beer actualBeer = sut.GetById(expectedBeer.Id);

			// Assert
			Assert.AreEqual(expectedBeer.Id, actualBeer.Id);
			Assert.AreEqual(expectedBeer.Name, actualBeer.Name);
			Assert.AreEqual(expectedBeer.Abv, actualBeer.Abv);
			Assert.AreEqual(expectedBeer.StyleId, actualBeer.StyleId);
			Assert.AreEqual(expectedBeer.CreatedById, actualBeer.CreatedById);
		}

		[TestMethod]
		public void ThrowException_When_BeerNotFound()
		{
			// Arrange
			var repositoryMock = new Mock<IBeersRepository>();
			
			repositoryMock
				.Setup(repo => repo.GetById(It.IsAny<int>()))
				.Throws(new EntityNotFoundException("Beer doesn't exist."));

			// Act
			var sut = new BeersService(repositoryMock.Object);

			Assert.ThrowsException<EntityNotFoundException>(() => sut.GetById(1));
		}
	}
}

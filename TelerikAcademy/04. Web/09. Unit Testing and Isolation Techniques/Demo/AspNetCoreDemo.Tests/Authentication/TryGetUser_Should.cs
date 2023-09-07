using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AspNetCoreDemo.Tests.Authorization
{
	[TestClass]
	public class TryGetUser_Should
	{
		[TestMethod]
		public void ReturnCorrectUser()
		{
			// Arrange
			var expectedUser = new User { Id = 1, Username = "TestUser" };
			var usersServiceMock = new Mock<IUsersService>();

			usersServiceMock.Setup(us => us.GetByUsername(It.IsAny<string>()))
				.Returns(expectedUser);

			var sut = new AuthManager(usersServiceMock.Object);

			// Act
			User actualUser = sut.TryGetUser("testHeaderValue");

			// Assert
			usersServiceMock.Verify(us => us.GetByUsername(It.IsAny<string>()), Times.Once());

			Assert.AreSame(expectedUser, actualUser);
		}
	}
}

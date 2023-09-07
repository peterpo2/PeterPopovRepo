using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;
using AspNetCoreDemo.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreDemo.Exceptions;

namespace AspNetCoreDemo.Tests.AuthManagerTest
{
    [TestClass]
    public class TryGetUserShould
    {
        [TestMethod]
        public void Return_CorrectUser_WhenParamsAreValid()
        {
            //Arrange
            User expectedUser = new User { Id = 1, Username = "TestUser", IsAdmin = false };

            var userServiceMock = new Mock<IUsersService>();

            userServiceMock.Setup(userService=>userService
                .GetByUsername("TestUser"))
                .Returns(expectedUser);

            var sut = new AuthManager(userServiceMock.Object);

            // Act

            User actualUser = sut.TryGetUser("TestUser");

            Assert.AreSame(expectedUser, actualUser);

        }

        [TestMethod]
        public void Throws_WhenParamsAreInvalid()
        {
            // Arrange
            User user = new User { Id = 1, Username = "TestUser", IsAdmin = false };
            var userServiceMock = new Mock<IUsersService>();

            userServiceMock
                .Setup(userService => userService.GetByUsername(It.IsAny<string>()))
                .Throws(new EntityNotFoundException($"User with username={user.Username} doesn't exist."));

            var sut = new AuthManager(userServiceMock.Object);

            // Act & Assert

            Assert.ThrowsException<UnauthorizedOperationException>(()=>sut.TryGetUser(It.IsAny<string>()));

        }
    }
}

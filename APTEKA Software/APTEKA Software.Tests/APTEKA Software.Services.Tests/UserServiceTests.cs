using APTEKA_Software.Exeptions;
using APTEKA_Software.Helpers;
using APTEKA_Software.Models;
using APTEKA_Software.Repositories.Contracts;
using APTEKA_Software.Services;
using APTEKA_Software.Services.Contracts;
using Moq;

namespace APTEKA_Software.Tests.APTEKA_Software.Services.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private IUserService userService;
        private Mock<IUserRepository> userRepositoryMock;
        private AuthManager authManager;

        [TestInitialize]
        public void Initialize()
        {
            userRepositoryMock = new Mock<IUserRepository>();
            userService = new UserService(userRepositoryMock.Object);
        }

        [TestMethod]
        public void TestGetUserById()
        {
            // Arrange
            int userId = 1;
            var expectedUser = new User { UserId = userId};
            userRepositoryMock.Setup(repo => repo.GetUser(userId)).Returns(expectedUser);

            // Act
            var result = userService.GetUser(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userId, result.UserId);
        }
        [TestMethod]
        public void TestCreateUser_Success()
        {
            // Arrange
            var newUser = new User { Username = "testuser"};
            userRepositoryMock.Setup(repo => repo.CheckUsername(newUser.Username)).Returns(false);
            userRepositoryMock.Setup(repo => repo.CreateUser(newUser)).Returns(newUser);

            // Act
            var result = userService.CreateUser(newUser);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newUser, result);
            userRepositoryMock.Verify(repo => repo.CheckUsername(newUser.Username), Times.Once);
            userRepositoryMock.Verify(repo => repo.CreateUser(newUser), Times.Once);
        }

        [TestMethod]
        public void TestCreateUser_DuplicateUsername()
        {
            // Arrange
            var existingUser = new User { Username = "existinguserche"};
            var newUser = new User { Username = "existinguserche"};
            userRepositoryMock.Setup(repo => repo.CheckUsername(existingUser.Username)).Returns(true);

            // Act & Assert
            Assert.ThrowsException<DuplicateEntityException>(() => userService.CreateUser(newUser));
            userRepositoryMock.Verify(repo => repo.CheckUsername(newUser.Username), Times.Once);
            userRepositoryMock.Verify(repo => repo.CreateUser(newUser), Times.Never);
        }
        [TestMethod]
        public void TestUpdateUser_Success()
        {
            // Arrange
            int userId = 1;
            var userToUpdate = new User { UserId = userId, FirstName = "John", LastName = "Johnson" };
            var updatedUserInfo = new User { FirstName = "Jane", LastName = "Janeson" };
            userRepositoryMock.Setup(repo => repo.GetUser(userId)).Returns(userToUpdate);
            userRepositoryMock.Setup(repo => repo.UpdateUser(userToUpdate)).Returns(updatedUserInfo);

            // Act
            var result = userService.UpdateUser(userId, updatedUserInfo,this.authManager.CurrentUser);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedUserInfo.FirstName, result.FirstName);
            Assert.AreEqual(updatedUserInfo.LastName, result.LastName);
            userRepositoryMock.Verify(repo => repo.GetUser(userId), Times.Once);
            userRepositoryMock.Verify(repo => repo.UpdateUser(userToUpdate), Times.Once);
        }

        [TestMethod]
        public void TestDeleteUser_Success()
        {
            // Arrange
            int userId = 1;
            var userToDelete = new User { UserId = userId };
            userRepositoryMock.Setup(repo => repo.GetUser(userId)).Returns(userToDelete);
            userRepositoryMock.Setup(repo => repo.DeleteUser(userId)).Returns(true);

            // Act
            var result = userService.DeleteUser(userId, userToDelete);

            // Assert
            Assert.IsTrue(result); 
            userRepositoryMock.Verify(repo => repo.GetUser(userId), Times.Once);
            userRepositoryMock.Verify(repo => repo.DeleteUser(userId), Times.Once);
        }
        [TestMethod]
        public void TestDeleteUser_Failure()
        {
            // Arrange
            int userId = 1;
            var userToDelete = new User { UserId = userId };
            userRepositoryMock.Setup(repo => repo.GetUser(userId)).Returns(userToDelete);
            userRepositoryMock.Setup(repo => repo.DeleteUser(userId)).Returns(false);

            // Act
            var result = userService.DeleteUser(userId, userToDelete);

            // Assert
            Assert.IsFalse(result);
            userRepositoryMock.Verify(repo => repo.GetUser(userId), Times.Once);
            userRepositoryMock.Verify(repo => repo.DeleteUser(userId), Times.Once);
        }

        [TestMethod]
        public void TestGetUserByUsername()
        {
            // Arrange
            string username = "testuserche";
            var expectedUser = new User { Username = username };
            userRepositoryMock.Setup(repo => repo.GetUserByUsername(username)).Returns(expectedUser);

            // Act
            var result = userService.GetUserByUsername(username);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(username, result.Username);
            userRepositoryMock.Verify(repo => repo.GetUserByUsername(username), Times.Once);
        }
        [TestMethod]
        public void TestGetAllUsers()
        {
            // Arrange
            var userList = new List<User>
            {
                new User { UserId = 1, Username = "user1" },
                new User { UserId = 2, Username = "user2" },
                new User { UserId = 3, Username = "user3" }
            };
            userRepositoryMock.Setup(repo => repo.GetAllUsers()).Returns(userList);

            // Act
            var result = userService.GetAllUsers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(userList.Count, result.Count);
            for (int i = 0; i < userList.Count; i++)
            {
                Assert.AreEqual(userList[i].UserId, result[i].UserId);
                Assert.AreEqual(userList[i].Username, result[i].Username);
            }
            userRepositoryMock.Verify(repo => repo.GetAllUsers(), Times.Once);
        }
        [TestMethod]
        public void TestDeleteUser_Unauthorized()
        {
            // Arrange
            int userIdToDelete = 1;
            var userToDelete = new User { UserId = userIdToDelete };
            var unauthorizedUser = new User { UserId = 2 };
            userRepositoryMock.Setup(repo => repo.GetUser(userIdToDelete)).Returns(userToDelete);

            // Act & Assert
            Assert.ThrowsException<UnauthorizedOperationException>(() => userService.DeleteUser(userIdToDelete, unauthorizedUser));
            userRepositoryMock.Verify(repo => repo.GetUser(userIdToDelete), Times.Once);
            userRepositoryMock.Verify(repo => repo.DeleteUser(userIdToDelete), Times.Never);
        }
        [TestMethod]
        public void TestUsernameExists_UsernameExists()
        {
            // Arrange
            string existingUsername = "existinguser";
            userRepositoryMock.Setup(repo => repo.GetUserByUsername(existingUsername)).Returns(new User());

            // Act
            bool result = userService.UsernameExists(existingUsername);

            // Assert
            Assert.IsTrue(result);
            userRepositoryMock.Verify(repo => repo.GetUserByUsername(existingUsername), Times.Once);
        }

    }
}

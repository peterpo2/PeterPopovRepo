using Moq;
using System;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;

namespace AspNetCoreDemo.Tests.Examples
{
	class MoqExamples
	{
		//A list of some of the features Moq provides.
		//Check the quickstart guide for more: https://github.com/Moq/moq4/wiki/Quickstart
		public void Examples()
		{
			//Create a mock object
			var mockService = new Mock<IUsersService>();


			//Setup Behavior
			mockService.Setup(x => x.GetByUsername("TestUser"))
				.Returns(new User { Id = 1, Username = "TestUser" });


			//Matching Arguments
			mockService.Setup(x => x.GetByUsername(It.IsAny<string>()))
				.Returns(new User { Id = 1, Username = "TestUser" });


			//Throw when invoking with specific arguments
			mockService.Setup(x => x.GetByUsername("Peter"))
			   .Throws<InvalidOperationException>();


			//Setup sequential calls
			mockService.SetupSequence(x => x.GetByUsername(It.IsAny<string>()))
			   .Returns(new User { Id = 1, Username = "TestUser1" })
			   .Returns(new User { Id = 2, Username = "TestUser2" })
			   .Returns(new User { Id = 3, Username = "TestUser3" })
			   .Returns(new User { Id = 4, Username = "TestUser4" });


			//Verify a method was never called
			mockService.Verify(x => x.GetByUsername(It.IsAny<string>()), Times.Never());


			//Verify a method was called once
			mockService.Verify(x => x.GetByUsername(It.IsAny<string>()), Times.Once());
		}
	}
}

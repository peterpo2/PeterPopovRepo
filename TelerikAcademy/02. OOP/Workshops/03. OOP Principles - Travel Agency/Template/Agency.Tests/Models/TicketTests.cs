using Agency.Exceptions;
using Agency.Models;
using Agency.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agency.Tests.Models
{
    [TestClass]
    public class TicketTests
    {
        [TestMethod]
        [DataRow(double.MinValue)]
        public void Constructor_Should_ThrowException_When_CostsAreNegative(double testValue)
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Ticket(
                    id: 1,
                    journey: TestHelpers.GetTestJourney(),
                    administrativeCosts: testValue));
        }
    }
}

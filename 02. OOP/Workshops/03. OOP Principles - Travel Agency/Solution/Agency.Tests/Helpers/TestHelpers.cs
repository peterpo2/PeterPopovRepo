using Agency.Models.Contracts;
using Agency.Models;
using System.Collections.Generic;
using Agency.Core.Contracts;
using Agency.Core;
using System.Linq;

namespace Agency.Tests.Helpers
{
    public class TestHelpers
    {
        public static List<string> GetListWithSize(int size)
        {
            return new string[size].ToList();
        }

        public static IRepository GetTestRepository()
        {
            return new Repository();
        }

        public static IVehicle GetTestVehicle()
        {
            return new Bus(
                    id: 1,
                    passengerCapacity: Bus.PassengerCapacityMinValue,
                    pricePerKilometer: Bus.PricePerKilometerMinValue,
                    hasFreeTv: true);
        }

        public static IJourney GetTestJourney()
        {
            return new Journey(
                    id: 1,
                    from: new string('x', Journey.StartLocationMinLength),
                    to: new string('x', Journey.DestinationMinLength),
                    distance: Journey.DistanceMinValue,
                    vehicle: GetTestVehicle());
        }
    }
}

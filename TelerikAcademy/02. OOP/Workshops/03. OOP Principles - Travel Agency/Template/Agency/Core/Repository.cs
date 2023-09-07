using Agency.Core.Contracts;
using Agency.Exceptions;
using Agency.Models;
using Agency.Models.Contracts;

using System;
using System.Collections.Generic;

namespace Agency.Core
{
    public class Repository : IRepository
    {
        private readonly List<IVehicle> vehicles = new List<IVehicle>();
        private readonly List<IJourney> journeys = new List<IJourney>();
        private readonly List<ITicket> tickets = new List<ITicket>();

        public IList<IVehicle> Vehicles
        {
            get
            {
                var copy = new List<IVehicle>(vehicles);
                return copy;
            }
        }
        public IList<IJourney> Journeys
        {
            get
            {
                var copy = new List<IJourney>(journeys);
                return copy;
            }
        }
        public IList<ITicket> Tickets
        {
            get
            {
                var copy = new List<ITicket>(tickets);
                return copy;
            }
        }

        public IBus CreateBus(int passengerCapacity, double pricePerKilometer, bool hasFreeTv)
        {
            var nextId = vehicles.Count;
            var bus = new Bus(++nextId, passengerCapacity, pricePerKilometer, hasFreeTv);
            this.vehicles.Add(bus);
            return bus;
        }

        public IAirplane CreateAirplane(int passengerCapacity, double pricePerKilometer, bool isLowCost)
        {
            throw new NotImplementedException();
        }

        public ITrain CreateTrain(int passengerCapacity, double pricePerKilometer, int carts)
        {
            throw new NotImplementedException();
        }

        public IJourney CreateJourney(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public ITicket CreateTicket(IJourney journey, double administrativeCosts)
        {
            throw new NotImplementedException();
        }

        public IVehicle FindVehicleById(int id)
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Id == id)
                {
                    return vehicle;
                }
            }

            throw new EntityNotFoundException($"Vehicle with id: {id} was not found!");
        }

        public IJourney FindJourneyById(int id)
        {
            throw new NotImplementedException();
        }

        public ITicket FindTicketById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

namespace Agency.Models.Contracts
{
    public interface IVehicle : IHasId
    {
        int PassengerCapacity { get; }
        double PricePerKilometer { get; }
    }
}
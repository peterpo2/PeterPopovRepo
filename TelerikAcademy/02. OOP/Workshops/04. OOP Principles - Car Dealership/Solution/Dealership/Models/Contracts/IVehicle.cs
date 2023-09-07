namespace Dealership.Models.Contracts
{
    public interface IVehicle : ICommentable, IPriceable
    {
        string Make { get; }

        string Model { get; }

        VehicleType Type { get; }

        int Wheels { get; }
    }
}

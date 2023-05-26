namespace Composition
{
    public class Citizen
    {
        public string Name { get; set; }

        public Address Address { get; set; }

        public Citizen(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public override string ToString()
        {
            return $"{Name} lives in {Address.City}, {Address.Street}";
        }
    }
}

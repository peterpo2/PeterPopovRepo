namespace Composition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Address address = new Address("Sofia", "Alexander Malinov");
            Citizen citizen = new Citizen("Peter", address);

            Console.WriteLine(citizen);
        }
    }
}
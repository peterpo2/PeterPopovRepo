namespace Constructors
{
    public class Person
    {
        public string name;

        public Person()
        {
            name = "Anonymous";
        }

        public Person(string personName)
        {
            name = personName;
        }

        public void SayName()
        {
            Console.WriteLine($"Hi, my name is {name}.");
        }
    }
}

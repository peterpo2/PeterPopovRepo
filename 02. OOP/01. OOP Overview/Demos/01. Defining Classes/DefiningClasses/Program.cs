namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.name = "John";
            person1.SayName(); // Hi, my name is John.

            Person person2 = new Person();
            person2.name = "Jill";
            person2.SayName(); // Hi, my name is Jill.
        }
    }
}
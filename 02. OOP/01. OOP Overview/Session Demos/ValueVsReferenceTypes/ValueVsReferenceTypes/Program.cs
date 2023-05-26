namespace ValueVsReferenceTypes
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("John", 30);
            int number = 5;

            Console.WriteLine($"number = {number}");
            Console.WriteLine($"Person name: {person.name}, age: {person.age}");

            ChangeValues(number, person);

            Console.WriteLine($"number = {number}");
            Console.WriteLine($"Person name: {person.name}, age: {person.age}");
        }

        static void ChangeValues(int number, Person person)
        {
            number++;
            person.name = "Mike";
            person.age = 20;
        }
    }

    class Person
    {
        public string name;
        public int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}
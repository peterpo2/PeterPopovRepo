using System.Net;

namespace OopSessionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person p1 = new Person("Jack", 21, new Address("Bulgaria", "Plovdiv"));
            //p1.Introduce();

            //User user = new User("dev97", "12345", "Jack", "Smith");
        }
    }

    class Person
    {
        public string name;
        public int age;
        public Address address;

        public Person()
        {
            name = "Anonymous";
        }

        public Person(string personName, int personAge, Address personAddress)
        {
            name = personName;
            age = personAge;
            address = personAddress;
        }

        public Person(string name, int age, string country, string city)
        {
            this.name = name;
            this.age = age;
            this.address = new Address(country, city);
        }

        public void Introduce()
        {
            Console.WriteLine($"Hi, I am {name} and I'm {age} years old. I'm from {address.city}, {address.country}");
        }
    }
}
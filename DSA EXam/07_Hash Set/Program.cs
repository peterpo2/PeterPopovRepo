namespace _07_Hash_Set
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> people = new HashSet<Person>();

            people.Add(new Person("Alice"));
            people.Add(new Person("Bob"));
            people.Add(new Person("Alice"));
            people.Add(new Person("Bob"));

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }

    public class Person
    {
        string name;
        
        public Person(string name) 
        {
            this.name = name;
        }

        public override string ToString() 
        {
            return this.name;
        }
    }
}
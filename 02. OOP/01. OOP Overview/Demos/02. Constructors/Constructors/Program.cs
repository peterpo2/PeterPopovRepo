namespace Constructors
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person jack = new Person("Jack");
            jack.SayName();// Hi, I'm Jack.

            Person unknown = new Person();
            unknown.SayName(); // Hi, I'm Anonymous.
        }
    }
}
using System;

namespace StaticConstructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Course.startTime.ToShortDateString());
        }
    }

    static class Course
    {
        public static DateTime startTime;

        //A static constructor is declared with the help of static keyword.
        //It is used to initialize any static data, or to perform a particular action that needs to be performed once only.
        //It is called automatically before the first instance is created(if class is non-static) or any static members are referenced.
        //More info - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors
        static Course()
        {
            startTime = DateTime.Now;
        }
    }
}

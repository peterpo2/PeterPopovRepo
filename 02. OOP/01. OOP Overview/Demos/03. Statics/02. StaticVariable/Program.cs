using System;

namespace StaticVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            //Static variables are accessed with the name of the class, they do not require an instance of that class for access.
            Console.WriteLine(Course.name);
        }
    }

    static class Course
    {
        //A static variable is declared with the help of static keyword. 
        //When a variable is declared as static, then a single copy of the variable is created and shared among all objects at the class level.
        public static string name = "This is C# OOP";
    }
}

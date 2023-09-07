using System;

namespace StaticMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //Static methods are accessed with the name of the class.
            Course.PrintName();
        }
    }

    static class Course
    {
        public static string name = "This is C# OOP";

        //A static method is declared with the help of static keyword.
        //Static method keeps only one copy of the method at the Type level, not the object level. That means, all instances of the class share the same copy of the method and its data.
        public static void PrintName()
        {
            Console.WriteLine(name);
        }
    }
}

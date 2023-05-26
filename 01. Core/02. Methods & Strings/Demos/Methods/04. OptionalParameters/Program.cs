using System;

class Program
{
    static void Main()
    {
        // calling with default value of optional param
        PrintWelcomeMessage();

        Console.WriteLine("\n--------------\n");

        // providing another value for the optional param
        PrintWelcomeMessage("Steven");
    }

    static void PrintWelcomeMessage(string name = "user")
    {
        Console.WriteLine($"Hello, {name}!");
        Console.WriteLine("Enjoy using our system");
        Console.WriteLine("If you have any issues, type --help");
        Console.WriteLine($"Have a nice {DateTime.Now.DayOfWeek}!");
    }
}

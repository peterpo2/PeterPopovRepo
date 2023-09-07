using System;

class Program
{
    static void Main()
    {
        PrintWelcomeMessage();

        Console.WriteLine("\n--------------\n");

        PrintWelcomeMessage("Steven");
    }

    static void PrintWelcomeMessage()
    {
        PrintWelcomeMessage("user");
    }

    static void PrintWelcomeMessage(string name)
    {
        Console.WriteLine($"Hello, {name}!");
        Console.WriteLine("Enjoy using our system");
        Console.WriteLine("If you have any issues, type --help");
        Console.WriteLine($"Have a nice {DateTime.Now.DayOfWeek}!");
    }
}

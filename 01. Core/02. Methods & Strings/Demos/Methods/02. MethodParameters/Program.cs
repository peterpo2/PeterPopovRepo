using System;

class Program
{
    static void Main()
    {
        Console.Write("Name? ");
        string name = Console.ReadLine();

        PrintWelcomeMessage(name); // name MUST be string
    }

    static void PrintWelcomeMessage(string name)
    {
        Console.WriteLine($"Hello, {name}!");
        Console.WriteLine("Enjoy using our system");
        Console.WriteLine("If you have any issues, type --help");
        Console.WriteLine($"Have a nice {DateTime.Now.DayOfWeek}!");
    }
}

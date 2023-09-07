using System;

class Program
{
    static void Main()
    {
        string name = GetValidUsername();

        PrintWelcomeMessage(name); // name MUST be string
    }

    static string GetValidUsername()
    {
        Console.Write("Name? ");
        string name = Console.ReadLine();

        // IsUsernameValid returns bool so it can be used wherever bool is expected - like in while
        while (!IsUsernameValid(name))
        {
            Console.Write("Please use only letters for your username: ");
            name = Console.ReadLine();
        }

        return name;
    }

    static bool IsUsernameValid(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            // code after 'return' is not executed
            return false;
        }

        foreach (char ch in name)
        {
            if (!char.IsLetter(ch))
            {
                // another 'early exit' - if we reach a character that is not a letter, 
                // there is no point to check the others
                return false;
            }
        }

        // if the flow reaches here, name is valid
        return true;
    }

    static void PrintWelcomeMessage(string name)
    {
        Console.WriteLine($"Hello, {name}!");
        Console.WriteLine("Enjoy using our system");
        Console.WriteLine("If you have any issues, type --help");
        Console.WriteLine($"Have a nice {DateTime.Now.DayOfWeek}!");
    }
}

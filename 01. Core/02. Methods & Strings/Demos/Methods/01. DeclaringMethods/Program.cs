using System;

class Program
{
    static void Main()
    {
        // Methods are also known as functions.
        // Methods are reusable blocks of code that can be invoked ("called") multiple times.
        // To call a method use its name followed by ().
        // The following will call the method DisplayLatestNews()
        DisplayLatestNews();
    }

    // This is a method a.k.a function.
    // Methods allow for reusing code.
    static void DisplayLatestNews()
    {
        string today = DateTime.Now.DayOfWeek.ToString();
        Console.WriteLine("Welcome, human!");
        Console.WriteLine($"Today is {today}.");
        Random randomGenerator = new Random();
        int randomTemperature = randomGenerator.Next(-10, 10);
        Console.WriteLine($"The temperature outside is {randomTemperature}°");
    }
}

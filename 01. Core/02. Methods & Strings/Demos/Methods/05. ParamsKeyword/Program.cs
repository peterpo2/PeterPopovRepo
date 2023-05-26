using System;

class Program
{
    static void Main()
    {
        CalculateRandomResultsForStudent("Steven", "C#", "C# OOP", "Databases", "ASP.NET");
        CalculateRandomResultsForStudent("Martin", "Functional JS", "Angular");
    }

    // The method that we use to calculate student exam results
    // IMPORTANT NOTE: 
    //     DONT EVER SHOW TO ANYONE!!
    static void CalculateRandomResultsForStudent(string studentName, params string[] exams) // 'params' MUST always be last in argument list 
    {
        Console.WriteLine($"{studentName}'s exam result:");
        var rnd = new Random();
        foreach (var exam in exams)
        {
            Console.WriteLine($" {exam}: {rnd.Next(1, 101)}");
        }
        Console.WriteLine("---------------------");
    }
}

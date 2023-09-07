using Boarder.Models;
using System;

namespace Boarder
{
    class Program
    {
        static void Main(string[] args)
        {
            var tomorrow = DateTime.Now.AddDays(1);
            var issue = new Issue("App flow tests?", "We need to test the App!", tomorrow);
            var task = new Task("Test the application flow", "Pesho", tomorrow);

            Board.AddItem(issue);
            Board.AddItem(task);
            Console.WriteLine(Board.TotalItems); // 2
        }
    }
}

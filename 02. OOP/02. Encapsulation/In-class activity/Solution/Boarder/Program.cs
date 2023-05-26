using System;

namespace Boarder
{
    class Program
    {
        static void Main(string[] args)
        {
            var item = new BoardItem("Refactor this mess", DateTime.Now.AddDays(2));
            item.DueDate = item.DueDate.AddYears(2);
            item.Title = "Not that important";
            item.RevertStatus();
            item.AdvanceStatus();
            item.RevertStatus();

            Console.WriteLine(item.ViewHistory());
        }
    }
}

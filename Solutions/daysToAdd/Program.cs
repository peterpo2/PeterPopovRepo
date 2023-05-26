using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string[] parts = Console.ReadLine().Split(' ');
        int day = int.Parse(parts[0]);
        int year = int.Parse(parts[2]);
        int temperature = int.Parse(Console.ReadLine());
        int rain = int.Parse(Console.ReadLine());
        int winterLength = int.Parse(Console.ReadLine());

        int month = Array.IndexOf(
            new string[] { "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December" },
            parts[1]) + 1;

        DateTime expectedDate = new DateTime(year, month, day);

        int daysToAdjust = 0;
        daysToAdjust += (winterLength - 70) / 7; 
        daysToAdjust += Math.Max(0, temperature - 20); 
        daysToAdjust += (rain - 30) / 3; 
        if (year % 4 == 0 && month <= 2)
        {
            daysToAdjust += 5; 
        }

        DateTime earliestDate = expectedDate.AddDays(-daysToAdjust);
        DateTime latestDate = expectedDate.AddDays(daysToAdjust);

        DateTime actualDate;
        if (earliestDate >= expectedDate)
        {
            actualDate = earliestDate;
        }
        else if (latestDate <= expectedDate)
        {
            actualDate = latestDate;
        }
        else
        {
            actualDate = expectedDate;
        }

        Console.WriteLine("{0:dd MMMM yyyy}", actualDate);
    }
}

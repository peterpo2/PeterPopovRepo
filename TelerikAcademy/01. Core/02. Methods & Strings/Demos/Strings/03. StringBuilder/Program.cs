using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main()
    {
        int count = 100000;
        string str = string.Empty;
        StringBuilder strBuilder = new StringBuilder();
        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < count; i++)
        {
            str += i;
        }
        Console.WriteLine($"String concatenate: {sw.ElapsedMilliseconds}"); // ~ 12500 ms

        sw.Restart();

        for (int i = 0; i < count; i++)
        {
            strBuilder.Append(i);
        }
        Console.WriteLine($"StringBuilder append: {sw.ElapsedMilliseconds}"); // ~ 10 ms
    }
}

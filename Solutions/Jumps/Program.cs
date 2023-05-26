using System;
using System.Linq;

namespace Jumps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] result = new int[n];
            for (int i = 0; i < n - 1; i++)
            {
                int currentNumber = input[i];
                for (int j = i + 1; j < n; j++)
                {
                    if (currentNumber < input[j])
                    {
                        currentNumber = input[j];
                        result[i]++;
                    }
                }

            }
            Console.WriteLine(result.Max());
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
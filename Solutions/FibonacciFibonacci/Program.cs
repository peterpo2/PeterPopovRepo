using System;
using System.Collections.Generic;
using System.Linq;

namespace FibonacciFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IterativeFibonacci(7));
        }
        static long IterativeFibonacci(long n)
        {
            if(n ==0)
            {
                return n;
            }
            long previous = 0;
            long result = 1;
            long current = 1;
            for (int i = 1; i < n; i++)
            {
                current = result;
                result = previous + current;
                previous = current;
            }
            return result;
        }
    }
}
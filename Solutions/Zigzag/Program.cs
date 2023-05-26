using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
namespace ZigZag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] nm = input.Split(' ').Select(int.Parse).ToArray();
            int cycles = 0;
            int counter = 0;
            int currentStepValue = 1;
            long sum = 1;

            if (nm[0] == 2)
            {
                cycles = 1;
                counter = 1;
            }
            else
            {
                counter = nm[0] - 1;
                if (nm[0] % 2 == 0)
                {
                    cycles = nm[0] / 2;
                }
                else
                {
                    cycles = (nm[0] - 1) / 2;
                }
            }

            for (int s = 0; s < cycles; s++)
            {

                for (int i = 0; i < nm[1] - 1; i++)
                {
                    if ((i + 2) % 2 == 0)
                    {
                        currentStepValue += 6;
                    }
                    sum += currentStepValue;
                }
                counter--;
                if (counter == 0)
                {
                    break;
                }

                for (int i = nm[1] - 1; i > 0; i--)
                {
                    if ((i + 2) % 2 == 0)
                    {
                        currentStepValue -= 6;
                    }
                    sum += currentStepValue;
                }
                counter--;
            }
            Console.WriteLine(sum);


        }
    }
}
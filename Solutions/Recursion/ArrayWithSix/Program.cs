using System.Reflection.Metadata.Ecma335;

namespace ArrayWith6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .ToArray();
            int index = int.Parse(Console.ReadLine());

            Console.WriteLine(ContainsSix(numbers, index).ToString().ToLower());

        }

        static bool ContainsSix(int[] numbers, int index)
        {

            if (index == numbers.Length)
            {
                return false;
            }

            if (numbers[index] == 6)
            {
                return true;
            }

            else
            {
                return ContainsSix(numbers, index + 1);
            }

        }
    }
}
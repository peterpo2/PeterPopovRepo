using System.Security;

namespace Longest_Sequence_of_Equal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //int[] array = InitialiseArray(n);
            int[] array = new int[n];
            FillArray(array);

            int longestSequence = 1;
            int currentSequence = 1;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i-1])
                {
                    currentSequence++;
                    if (currentSequence>longestSequence)
                    {
                        longestSequence = currentSequence;
                    }
                }
                else
                {
                    currentSequence = 1;
                }
            }
            Console.WriteLine(longestSequence);
        }

        static int[] InitialiseArray(int size)
        {
            int[] numbers = new int[size];
            for (int i = 0; i < size; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            return numbers;
        }

        static void FillArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
        }
    }
}
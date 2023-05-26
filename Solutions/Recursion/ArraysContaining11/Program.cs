namespace ArraysContaining11
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

            Console.WriteLine(ContainsEleven(numbers, index));

        }

        static int ContainsEleven(int[] numbers, int index)
        {

            if(index == numbers.Length) 
            {
                return 0;
            }

            else if (numbers[index] == 11)
            {
                return 1 + ContainsEleven(numbers, index+1);
            }

            else
            {
                return 0 + ContainsEleven(numbers, index+1);
            }

        }
    }
}
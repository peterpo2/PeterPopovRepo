namespace ArraysValuesTimes10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine((ContainsNumberWithItsTimes10Value(numbers, index).ToString().ToLower()));
        }

        static bool ContainsNumberWithItsTimes10Value(int[] numbers, int index)
        {
            if(index + 1 == numbers.Length) 
            {
                return false;
            }

            else if (numbers[index + 1] == numbers[index] * 10)
            {
                return true;
            }

            else 
            {
                return ContainsNumberWithItsTimes10Value(numbers, index + 1);
            }
        }
    }
}
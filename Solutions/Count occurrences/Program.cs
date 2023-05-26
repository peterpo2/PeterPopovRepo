namespace Count_occurrences
{
    public class CountOccurrences
    {
        public static int CountSevens(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            int digit = n % 10;
            if (digit == 7)
            {
                return 1 + CountSevens(n / 10);
            }
            else
            {
                return CountSevens(n / 10);
            }
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int count = CountSevens(n);
            Console.WriteLine(count);
        }
    }

}
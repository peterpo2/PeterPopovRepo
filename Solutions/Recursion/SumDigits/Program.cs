namespace SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(SumDigits(n));
        }
        static int SumDigits(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            return n % 10 + SumDigits(n / 10);

        }
    }
}
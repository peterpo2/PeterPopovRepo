namespace CountOccurrences2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(CountOccurrences(n));
        }
        static int CountOccurrences(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            else if (n % 100 == 88)
            {

                return 2 + CountOccurrences(n / 10);
            }

            else if (n % 10 == 8)
            {

                return 1 + CountOccurrences(n / 10);
            }

            else
            {
                return 0 + CountOccurrences(n / 10);
            }


        }
    }
}
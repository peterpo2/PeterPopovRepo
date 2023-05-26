namespace CountOccurrences
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

          if (n % 10 == 7)
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
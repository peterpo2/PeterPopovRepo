namespace Factorial
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int result = Factorial(n);
            Console.WriteLine(result);
        }

        static int Factorial(int n)
        {
            // Bottom case
            if (n == 1)
            {
                return 1;
            }
            // If n is 5 => return 5 & Factorial(4)
            return n * Factorial(n - 1);
            //Factorial(5) = 5 * Factorial(4)
            //             = 5 * 4 * Factorial(3)
            //             = 5 * 4 * 3 * Factorial(2)
            //             = 5 * 4 * 3 * 2 * Factorial(1)
            //             = 5 * 4 * 3 * 2 * 1
            //             = 120
        }
    }
}
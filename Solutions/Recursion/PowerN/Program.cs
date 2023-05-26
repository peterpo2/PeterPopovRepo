namespace PowerN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int b = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(PowerN(b, n));
        }
        static int PowerN(int b, int n)
        {
            if (n == 0) 
            {
                return 1;
            }

            return b * PowerN(b, n-1);
        }
    }
}
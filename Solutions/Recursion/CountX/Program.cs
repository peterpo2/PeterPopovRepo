namespace CountX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(CountX(input));
        }

        static int CountX(string input)
        {
            if (input.Length == 0)
            {
                return 0;
            }

            if (input[0] == 'x')
            {
                return 1 + CountX(input.Substring(1));
            }
            else
            {
                return 0 + CountX(input.Substring(1));
            }

        }
    }
}
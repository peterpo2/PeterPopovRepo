namespace CountHi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(CountHi(input));
        }

        static int CountHi(string input)
        {
            if (input.Length == 0 || input.Length == 1)
            {
                return 0;
            }

            if (input[0] == 'h' && input[1] == 'i')
            {
                return 1 + CountHi(input.Substring(1));
            }
            else
            {
                return 0 + CountHi(input.Substring(1));
            }

        }
    }
}
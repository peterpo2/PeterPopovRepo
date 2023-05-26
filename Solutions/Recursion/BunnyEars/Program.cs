namespace BunnyEars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bunnies = int.Parse(Console.ReadLine());
            Console.WriteLine(BunnyEars(bunnies));
        }

        static int BunnyEars(int bunnies)
        {
            if (bunnies == 0)
            {
                return 0;
            }

            return 2 + BunnyEars(bunnies - 1);
        }
    }
}
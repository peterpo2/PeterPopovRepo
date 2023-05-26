namespace BunnyEars2
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

            else if (bunnies % 2 == 0)
            {
                return 3 + BunnyEars(bunnies - 1);
            }
            else
            {
                return 2 + BunnyEars(bunnies - 1);
            }
        }
    }
}

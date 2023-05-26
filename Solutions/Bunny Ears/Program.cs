namespace Bunny_Ears
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bunnies = int.Parse(Console.ReadLine());
            int ears = CountEars(bunnies);
            Console.WriteLine(ears);
        }
        public static int CountEars(int bunnies)
        {
            if (bunnies == 0)
            {
                return 0;
            }
            return 2 + CountEars(bunnies - 1);
        }
    }
}
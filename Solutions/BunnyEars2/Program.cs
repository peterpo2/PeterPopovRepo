namespace BunnyEars2
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
            if(bunnies == 0)
            {
                return 0;       
            }
            if (bunnies %2 == 0)
            {
                return 3+CountEars(bunnies -1 );
            }
            return 2+CountEars(bunnies-1);
        }
    }
}
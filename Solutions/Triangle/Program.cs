namespace Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int blocks = CountBlocks(rows);
            Console.WriteLine(blocks);
        }
        static int CountBlocks(int rows)
        {
            if (rows == 0) return 0;
            return rows + CountBlocks(rows - 1);
        }
    }
}
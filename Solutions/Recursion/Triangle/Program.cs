namespace Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine(TriangleOfRows(rows));
        }
        static int TriangleOfRows(int rows)
        {
            if (rows == 0)
            {
                return 0;
            }

            return rows + (TriangleOfRows(rows - 1));


        }
    }
}
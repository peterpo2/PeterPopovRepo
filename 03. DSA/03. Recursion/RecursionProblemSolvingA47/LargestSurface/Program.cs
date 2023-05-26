using System;
using System.Linq;

namespace LargestSurface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] field = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = input[col];
                }
            }

            bool[,] visited = new bool[rows, cols];

            int largestSurface = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!visited[row, col])
                    {
                        int surface = GetSurfaceLength(field, visited, row, col);
                        if (surface > largestSurface)
                        {
                            largestSurface = surface;
                        }
                    }
                }
            }

            Console.WriteLine(largestSurface);
        }

        static int GetSurfaceLength(int[,] field, bool[,] visited, int row, int col)
        {
            int result = 1;
            visited[row, col] = true;

            int current = field[row, col];

            // left
            if (col - 1 >= 0 && field[row, col - 1] == current && !visited[row, col - 1])
            {
                result += GetSurfaceLength(field, visited, row, col - 1);
            }

            // right
            if (col + 1 < field.GetLength(1) && field[row, col + 1] == current && !visited[row, col + 1])
            {
                result += GetSurfaceLength(field, visited, row, col + 1);
            }

            // up
            if (row - 1 >= 0 && field[row - 1, col] == current && !visited[row -1, col])
            {
                result += GetSurfaceLength(field, visited, row - 1, col);
            }

            // down
            if (row + 1 < field.GetLength(0) && field[row + 1, col] == current && !visited[row + 1, col])
            {
                result += GetSurfaceLength(field, visited, row + 1, col);
            }

            return result;
        }
    }
}
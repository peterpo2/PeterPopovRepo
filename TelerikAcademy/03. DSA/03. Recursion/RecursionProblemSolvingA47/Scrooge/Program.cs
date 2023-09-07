using System;
using System.Linq;

namespace Scrooge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] field = new int[rows, cols];

            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < rows; row++)
            {
                input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == 0)
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Console.WriteLine(CollectCoins(field, startRow, startCol));
        }

        static int CollectCoins(int[,] field, int row, int col)
        {
            int rowDirection = 0; // +1 or -1
            int colDirection = 0; // +1 or -1
            int max = 0;

            // try left, right, up, down
            // try left
            if (col - 1 >= 0 && field[row, col - 1] > max)
            {
                colDirection = -1;
                max = field[row, col - 1];
            }

            // try right
            if (col + 1 < field.GetLength(1) && field[row, col + 1] > max)
            {
                colDirection = 1;
                max = field[row, col + 1];
            }

            // try up
            if (row - 1 >= 0 && field[row - 1, col] > max)
            {
                rowDirection = -1;
                colDirection = 0;
                max = field[row - 1, col];
            }

            // try down
            if (row + 1 < field.GetLength(0) && field[row + 1, col] > max)
            {
                rowDirection = 1;
                colDirection = 0;
                max = field[row + 1, col];
            }

            // base case, if max is 0
            if (max == 0)
            {
                return 0;
            }

            // collect coin
            int nextRow = row + rowDirection;
            int nextCol = col + colDirection;

            field[nextRow, nextCol]--; // take the coin

            // recursive call
            return 1 + CollectCoins(field, nextRow, nextCol);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Small_world
{
    class Program
    {
        static int[,] board;
        static bool[,] visited;
        static int rows, cols;
        static int[] conquestSizes;

        static void Main()
        {
            string[] dimensions = Console.ReadLine().Split(' ');
            rows = int.Parse(dimensions[0]);
            cols = int.Parse(dimensions[1]);

            board = new int[rows, cols];
            visited = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = int.Parse(row[j].ToString());
                }
            }

            List<int> sizes = FindConquestSizes();
            sizes.Sort();
            sizes.Reverse();

            foreach (int size in sizes)
            {
                Console.WriteLine(size);
            }
        }
        static List<int> FindConquestSizes()
        {
            List<int> sizes = new List<int>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i, j] == 1 && !visited[i, j])
                    {
                        int size = DFS(i, j);
                        sizes.Add(size);
                    }
                }
            }

            return sizes;
        }

        static int DFS(int row, int col)
        {
            visited[row, col] = true;
            int size = 1;

            if (row > 0 && board[row - 1, col] == 1 && !visited[row - 1, col])
            {
                size += DFS(row - 1, col);
            }
            if (row < rows - 1 && board[row + 1, col] == 1 && !visited[row + 1, col])
            {
                size += DFS(row + 1, col);
            }
            if (col > 0 && board[row, col - 1] == 1 && !visited[row, col - 1])
            {
                size += DFS(row, col - 1);
            }
            if (col < cols - 1 && board[row, col + 1] == 1 && !visited[row, col + 1])
            {
                size += DFS(row, col + 1);
            }

            return size;
        }
    }
}
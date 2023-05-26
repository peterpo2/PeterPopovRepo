using System;

namespace MatrixMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(input[j]);
                }
            }

            string[] coordinates = Console.ReadLine().Split();
            int r1 = int.Parse(coordinates[0]) - 1;
            int c1 = int.Parse(coordinates[1]) - 1;
            int r2 = int.Parse(coordinates[2]) - 1;
            int c2 = int.Parse(coordinates[3]) - 1;

            int[,] dp = new int[n, n];
            dp[0, 0] = matrix[0, 0];
            for (int i = 1; i < n; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + matrix[i, 0];
                dp[0, i] = dp[0, i - 1] + matrix[0, i];
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = matrix[i, j] + Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            int sum1 = dp[r1, c1] + dp[r2, c2] - dp[r1, c2] - dp[r2, c1];
            Console.WriteLine(sum1);
        }
    }
}

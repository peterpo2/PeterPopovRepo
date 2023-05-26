using System;

class Program
{
    static void Main()
    {
        // Read input
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            string[] row = Console.ReadLine().Split();
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(row[j]);
            }
        }
        string[] coords = Console.ReadLine().Split();
        int r1 = int.Parse(coords[0]);
        int c1 = int.Parse(coords[1]);
        int r2 = int.Parse(coords[2]);
        int c2 = int.Parse(coords[3]);

        // Compute maximum sum for each pair of coordinates
        int maxSum = int.MinValue;
        for (int i = 0; i < 2; i++)
        {
            int r = i == 0 ? r1 : r2;
            int c = i == 0 ? c1 : c2;
            int sum = 0;
            while (true)
            {
                sum += matrix[r, c];
                if (r == (i == 0 ? r2 : r1) && c == (i == 0 ? c2 : c1)) // reached the other coordinate
                {
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                    }
                    break;
                }
                if (c < n - 1 && (c == (i == 0 ? c1 : c2) || matrix[r, c + 1] >= matrix[r, c - 1]))
                {
                    c++; // move right
                }
                else if (r < n - 1 && (r == (i == 0 ? r1 : r2) || matrix[r + 1, c] >= matrix[r - 1, c]))
                {
                    r++; // move down
                }
                else if (c > 0)
                {
                    c--; // move left
                }
                else
                {
                    r--; // move up
                }
            }
        }

        // Output result
        Console.WriteLine(maxSum);
    }
}

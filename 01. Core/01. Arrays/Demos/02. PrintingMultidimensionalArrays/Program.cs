using System;

class Program
{
    static void Main()
    {
        int[,] matrix = new int[,]
        {
            { 1, 2 },
            { 4, 5 },
            { 8, 9 }
        };

        // When you don't know the number of rows and columns of a matrix,
        // use GetLength(0) for rows and GetLength(1) for columns

        int rows = matrix.GetLength(0);
        Console.WriteLine($"The matrix has {rows} rows.");

        int columns = matrix.GetLength(1);
        Console.WriteLine($"The matrix has {columns} columns.");

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                Console.Write($" {matrix[r, c]} ");
            }

            Console.WriteLine();
        }

    }
}

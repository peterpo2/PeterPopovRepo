using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Let's start by defining the number of rows and columns in the matrix.");
        Console.WriteLine("How many rows do you want?");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("How many columns do you want?");
        int columns = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, columns];
        Console.WriteLine("Matrix created successfully!");

        Console.WriteLine("Now, let's fill the matrix with some numbers.");
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                // interpolated string
                Console.Write($"Enter a number for row: {row}, column: {column}: ");

                matrix[row, column] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Matrix filled with numbers successfully!");
        Console.WriteLine("Now, let's print the numbers stored in the matrix.");
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < columns; c++)
            {
                // interpolated string
                Console.Write($" {matrix[r, c]} ");
            }

            Console.WriteLine();
        }

        Console.WriteLine("Goodbye!");
    }
}

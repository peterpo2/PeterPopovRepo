using System;

class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        string[][] jagged = new string[size][];

        for (int i = 0; i < size; i++)
        {
            string line = Console.ReadLine();

            // Split the line by "," or any other symbol 
            string[] arrStrings = line.Split(',');

            // Assign the split array to the jagged at position "i"
            jagged[i] = arrStrings;
        }

        // jagged array printing
        for (int i = 0; i < jagged.Length; i++)
        {
            for (int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write(jagged[i][j]);
            }
            Console.WriteLine();
        }

        // jagged array printing with string.Join()
        for (int i = 0; i < jagged.Length; i++)
        {
            Console.WriteLine(string.Join(",", jagged[i]));
        }

    }
}

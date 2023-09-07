using System;

class Program
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());

        string[][] jagged = new string[rows][];

        for (int i = 0; i < rows; i++)
        {
            string line = Console.ReadLine();

            // Split the line by "," or any other symbol 
            string[] arrStrings = line.Split(',');

            // Assign the split array to the jagged at position "i"
            jagged[i] = arrStrings;
        }
    }
}

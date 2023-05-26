using System.Runtime.CompilerServices;
using System.Text;

namespace Variations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arrayLength = int.Parse(Console.ReadLine());
            char[] input = Console.ReadLine().Split().Select(char.Parse).ToArray();
            Array.Sort(input);
            var sb = new StringBuilder();
            Generator(new char[arrayLength], input[1], input[0], 0, sb);
            Console.WriteLine(sb.ToString());
        }

        static void Generator(char[] array, char firstSymbol, char secondSymbol, int index, StringBuilder sb)
        {
            if (index == array.Length)
            {
                sb.AppendLine(string.Join("", array));
                return;
            }
            array[index] = secondSymbol;
            Generator(array,firstSymbol, secondSymbol, index + 1, sb);
            array[index]=firstSymbol;
            Generator(array,firstSymbol, secondSymbol, index+1, sb);
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Just_count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> list = Console.ReadLine().ToList();


            Dictionary<char, char> chars = new Dictionary<char, char>();
            Dictionary<char, int> specSymbols = new Dictionary<char, int>();
            Dictionary<char, int> lowerLetters = new Dictionary<char, int>();
            Dictionary<char, int> upperLetters = new Dictionary<char, int>();

            foreach (char c in list)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    if (!chars.TryAdd(c, c))
                    {
                        specSymbols[c]++;
                    }
                    else
                    {
                        specSymbols.Add(c, 1);
                    }
                }
                if (char.IsLower(c))
                {
                    if (!chars.TryAdd(c, c))
                    {
                        lowerLetters[c]++;
                    }
                    else
                    {
                        lowerLetters.Add(c, 1);
                    }
                }
                if (char.IsUpper(c))
                {
                    if (!chars.TryAdd(c, c))
                    {
                        upperLetters[c]++;
                    }
                    else
                    {
                        upperLetters.Add(c, 1);
                    }
                }
            }

            PrintResult(specSymbols);
            PrintResult(lowerLetters);
            PrintResult(upperLetters);
        }

        static void PrintResult(Dictionary<char, int> dictionary)
        {
            if (dictionary.Count != 0)
            {

                var keyOfMaxValue = dictionary
                    .OrderByDescending(c => c.Key)
                    .Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

                Console.WriteLine($"{keyOfMaxValue} {dictionary[keyOfMaxValue]}");

            }
            else
            {
                Console.WriteLine("-");
            }
        }
    }
}
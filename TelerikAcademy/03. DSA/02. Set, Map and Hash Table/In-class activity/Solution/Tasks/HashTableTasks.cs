using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTables.InClassActivity
{
    public class HashTableTasks
    {
        /// <summary>
        /// Counts the number of occurrences of a each word in a collection.
        /// </summary>
        /// <param name="words">A collection of words.</param>
        /// <returns>A dictionary of occurrences by word.</returns>
        public static Dictionary<string, int> CountOccurences(string[] words)
        {
            var dictionary = new Dictionary<string, int>();
            foreach (string item in words)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary.Add(item, 0);
                }

                dictionary[item]++;
            }

            return dictionary;
        }

        /// <summary>
        /// Return the indices of the first two numbers that sum to a given number.
        /// </summary>
        /// <param name="numbers">Collection of numbers</param>
        /// <param name="sum">Target sum</param>
        /// <returns>An array containing the indices of the first two numbers that produce the target sum.</returns>
        public static int[] TwoSum(int[] numbers, int sum)
        {
            var map = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                int target = sum - numbers[i];

                if (map.ContainsKey(target))
                {
                    return new int[] { map[target], i };
                }
                else
                {
                    map.Add(numbers[i], i);
                }
            }

            return new int[] { -1, -1 };
        }

        /// <summary>
        /// Counts how many coins are special.
        /// </summary>
        /// <param name="coins">Coins to check.</param>
        /// <param name="catalogue">The catalogue of special coins.</param>
        /// <returns>The count of special coins</returns>
        public static int SpecialCoins(string coins, string catalogue)
        {
            var set = new HashSet<char>(catalogue);
            return coins.Aggregate(0, (specialCoinsCount, currentCoin) => specialCoinsCount + (set.Contains(currentCoin) ? 1 : 0));
        }

        /// <summary>
        /// Determines whether two strings are isomorphic. 
        /// Two strings are considered isomorphic if each character from the first string can map to a character in the seconds string.
        /// </summary>
        /// <param name="s1">The first string.</param>
        /// <param name="s2">The second string.</param>
        /// <returns>True if the two strings are isomorphic; otherwise, false.</returns>
        public static bool AreIsomorphic(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            var s1map = new Dictionary<char, char>();
            var s2map = new Dictionary<char, char>();

            for (int i = 0; i < s1.Length; i++)
            {
                char c1 = s1[i];
                char c2 = s2[i];

                if (!s1map.ContainsKey(c1))
                {
                    s1map.Add(c1, c2);
                }
                if (!s2map.ContainsKey(c2))
                {
                    s2map.Add(c2, c1);
                }

                if (s1map[c1] != c2 || s2map[c2] != c1)
                    return false;
            }

            return true;
        }
    }
}

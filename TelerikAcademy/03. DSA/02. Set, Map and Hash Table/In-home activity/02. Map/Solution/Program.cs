using System;
using System.Collections.Generic;

namespace InHomeActivity.Map
{
    class Program
    {
        static void Main()
        {
            // CountOccurrences
            var result = CountOccurrences(new[] { "js", "c#", "js", "c#", "c++" });
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            // Group
            var data = new[]
            {
                 new KeyValuePair<string,string>("US", "New York"),
                 new KeyValuePair<string,string>("BG", "Sofia"),
                 new KeyValuePair<string,string>("UK", "London"),
                 new KeyValuePair<string,string>("BG", "Plovdiv"),
                 new KeyValuePair<string,string>("UK", "Manchester"),
                 new KeyValuePair<string,string>("US", "Chicago")
             };

            var groupedData = Group(data);

            foreach (var item in groupedData)
            {
                Console.WriteLine($"{item.Key}: {string.Join(", ", item.Value)}");
            }
        }

        static Dictionary<string, List<string>> Group(KeyValuePair<string, string>[] data)
        {
            var dictionary = new Dictionary<string, List<string>>();

            foreach (var kvp in data)
            {
                if (!dictionary.ContainsKey(kvp.Key))
                {
                    dictionary.Add(kvp.Key, new List<string>());
                }

                dictionary[kvp.Key].Add(kvp.Value);
            }

            return dictionary;
        }

        static Dictionary<string, int> CountOccurrences(string[] array)
        {
            var dictionary = new Dictionary<string, int>();
            foreach (string item in array)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary.Add(item, 0);
                }

                dictionary[item]++;
            }

            return dictionary;
        }
    }
}

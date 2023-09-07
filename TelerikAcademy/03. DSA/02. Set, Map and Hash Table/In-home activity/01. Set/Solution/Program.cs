using System;
using System.Collections.Generic;
using System.Linq;

namespace InHomeActivity.Set
{
    class Program
    {
        static void Main()
        {
            // AreAllElementsUnique
            var array = new int[] { 1, 2, 3, 4 };
            Console.WriteLine(AreAllElementsUnique(array)); // true

            var list = new List<int>() { 1, 2, 3, 3 };
            Console.WriteLine(AreAllElementsUnique(list)); // false

            Console.WriteLine(AreAllElementsUnique("program")); // false

            Console.WriteLine(AreAllElementsUnique("pRogram")); // true

            // Distinct
            var uniqueCharacters = Distinct("abbbc");
            Console.WriteLine(string.Join(',', uniqueCharacters)); // a,b,c

            var uniqueNumbers = Distinct(new int[] { 1, 2, 3, 3, 4, 1 });
            Console.WriteLine(string.Join(',', uniqueNumbers)); // 1,2,3,4

            // Union
            var union1 = Union("abc", "bce");
            Console.WriteLine(string.Join(',', union1)); // a,b,c,e

            var union2 = Union("abc", "def");
            Console.WriteLine(string.Join(',', union2)); // a,b,c,d,e,f

            var collection1 = new int[] { 1, 5, 9 };
            var collection2 = new int[] { 3, 5, 8 };
            var union3 = Union(collection1, collection2);
            Console.WriteLine(string.Join(',', union3)); // 1,5,9,3,8

            // Intersection
            var intersection1 = Intersect("abc", "bce");
            Console.WriteLine(string.Join(',', intersection1)); // b,c

            var intersection2 = Intersect("abc", "def");
            Console.WriteLine(string.Join(',', intersection2)); // 

            collection1 = new int[] { 1, 5, 9 };
            collection2 = new int[] { 3, 5, 8 };
            var intersection3 = Intersect(collection1, collection2);
            Console.WriteLine(string.Join(',', intersection3)); // 5

            // Difference
            collection1 = new int[] { 1, 3, 5, 7, 9 };
            collection2 = new int[] { 2, 3, 4, 6 };
            var difference = Difference(collection1, collection2);
            Console.WriteLine(string.Join(',', difference)); // 1,5,7,9
        }

        static bool AreAllElementsUnique<T>(ICollection<T> collection)
        {
            var set = new HashSet<T>(collection);
            return set.Count == collection.Count;
        }
        static bool AreAllElementsUnique<T>(IEnumerable<T> collection)
        {
            var set = new HashSet<T>();

            foreach (var item in collection)
            {
                if (!set.Add(item))
                {
                    return false;
                }
            }

            return true;
        }

        static IEnumerable<T> Distinct<T>(IEnumerable<T> collection)
        {
            var set = new HashSet<T>(collection);
            return set;
        }

        static IEnumerable<T> Union<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            var set1 = new HashSet<T>(collection1);
            var set2 = new HashSet<T>(collection2);

            foreach (var item in set2)
            {
                set1.Add(item);
            }

            return set1;
        }

        static IEnumerable<T> Intersect<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            var set1 = new HashSet<T>(collection1);
            var set2 = new HashSet<T>(collection2);
            var intersection = new HashSet<T>();

            foreach (var item in set2)
            {
                if (set1.Contains(item))
                {
                    intersection.Add(item);
                }
            }

            return intersection;
        }

        static IEnumerable<T> Difference<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            var set1 = new HashSet<T>(collection1);
            var set2 = new HashSet<T>(collection2);
            var difference = new HashSet<T>();

            foreach (var item in set1)
            {
                if (!set2.Contains(item))
                {
                    difference.Add(item);
                }
            }

            return difference;
        }
    }
}

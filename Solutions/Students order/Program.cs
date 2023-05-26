using System;
using System.Collections.Generic;
using System.Linq;
namespace Students_order
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> list = Console.ReadLine().Split(' ').ToList();

            int numberStudents = int.Parse(input.Split(' ')[0]);
            int seatChanges = int.Parse(input.Split(' ')[1]);


            for (int i = 0; i < seatChanges; i++)
            {
                string changes = Console.ReadLine();

                string name1 = changes.Split(' ')[0];
                string name2 = changes.Split(" ")[1];

                int indexName1 = 0;
                int indexName2 = 0;
                var firstIsVisited = false;
                var secondIsVisited = false;

                for (int j = 0; j < list.Count; j++)
                {
                    if (secondIsVisited == false && list[j].Equals(name2))
                    {
                        indexName2 = j;
                        secondIsVisited = true;
                    }
                    if (firstIsVisited == false && list[j].Equals(name1))
                    {
                        indexName1 = j;
                        firstIsVisited = true;
                    }
                    if (firstIsVisited == true && secondIsVisited == true)
                    {
                        break;
                    }
                }
                if (indexName2 > indexName1)
                {
                    list.Insert(indexName2, name1);
                    list.RemoveAt(indexName1);
                }
                else
                {
                    list.Insert(indexName2, name1);
                    list.RemoveAt(indexName1 + 1);
                }

            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
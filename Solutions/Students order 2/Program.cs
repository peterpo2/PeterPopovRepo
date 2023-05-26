using System;
using System.Collections.Generic;
using System.Linq;

namespace Students_order_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);

            string[] students = Console.ReadLine().Split(' ');
            Dictionary<string, int> positions = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                positions[students[i]] = i;
            }

            for (int i = 0; i < k; i++)
            {
                string[] swap = Console.ReadLine().Split(' ');
                int pos1 = positions[swap[0]];
                int pos2 = positions[swap[1]];

                positions[swap[0]] = pos2;
                positions[swap[1]] = pos1;
                string temp = students[pos1];
                students[pos1] = students[pos2];
                students[pos2] = temp;
            }

            Console.WriteLine(string.Join(' ', students));
            //            using System;
            //            using System.Collections.Generic;
            //            using System.Linq;
            //            using System.Text;

            //class Program
            //        {
            //            static void Main()
            //            {
            //                int[] input = Console.ReadLine()
            //                    .Split()
            //                    .Select(int.Parse)
            //                    .ToArray();

            //                LinkedList<string> names = new LinkedList<string>(Console.ReadLine().Split());
            //                Dictionary<string, LinkedListNode<string>> dict = new Dictionary<string, LinkedListNode<string>>();

            //                LinkedListNode<string> current = names.First;
            //                while (current != null)
            //                {
            //                    dict[current.Value] = current;
            //                    current = current.Next;
            //                }

            //                for (int i = 0; i < input[1]; i++)
            //                {
            //                    string[] namesToMove = Console.ReadLine().Split();
            //                    string nameOne = namesToMove[0];
            //                    string nameTwo = namesToMove[1];

            //                    LinkedListNode<string> nameOneToMove = dict[nameOne];

            //                    names.Remove(nameOneToMove);
            //                    LinkedListNode<string> nameTwoToMove = dict[nameTwo];
            //                    names.AddBefore(nameTwoToMove, nameOneToMove);
            //                }

            //                Console.WriteLine(string.Join(" ", names));
            //            }
            //        }
        }
    }
}
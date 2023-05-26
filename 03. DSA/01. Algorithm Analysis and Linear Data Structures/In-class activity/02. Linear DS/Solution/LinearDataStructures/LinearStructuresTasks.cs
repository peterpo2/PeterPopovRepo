using System;
using System.Text;

using LinearDataStructures.Common;

namespace LinearDataStructures
{
    public static class LinearStructuresTasks
    {
        public static bool AreListsEqual<T>(SinglyLinkedList<T> list1, SinglyLinkedList<T> list2)
        {
            Node<T> a = list1.Head;
            Node<T> b = list2.Head;

            while (a != null && b != null)
            {
                if (!a.Value.Equals(b.Value))
                {
                    return false;
                }

                a = a.Next;
                b = b.Next;
            }

            return (a == null) && (b == null);
        }

        public static Node<T> FindMiddleNode<T>(SinglyLinkedList<T> list)
        {
            Node<T> slowPointer = list.Head; // Turtle
            Node<T> fastPointer = list.Head; // Rabbit

            while (fastPointer != null && fastPointer.Next != null)
            {
                slowPointer = slowPointer.Next;
                fastPointer = fastPointer.Next.Next;
            }

            return slowPointer;
        }

        public static SinglyLinkedList<T> MergeLists<T>(SinglyLinkedList<T> list1, SinglyLinkedList<T> list2) where T : IComparable
        {
            var mergedList = new SinglyLinkedList<T>(new T[] { default });

            Node<T> current = mergedList.Head;

            Node<T> h1 = list1.Head;
            Node<T> h2 = list2.Head;

            while (h1 != null && h2 != null)
            {
                if (h1.Value.CompareTo(h2.Value) == -1)
                {
                    current.Next = new Node<T>(h1.Value);
                    h1 = h1.Next;
                }
                else
                {
                    current.Next = new Node<T>(h2.Value);
                    h2 = h2.Next;
                }

                current = current.Next;
            }

            current.Next = h1 ?? h2;

            mergedList.RemoveFirst();
            return mergedList;
        }

        public static SinglyLinkedList<T> ReverseList<T>(SinglyLinkedList<T> list)
        {
            var reversed = new SinglyLinkedList<T>();

            Node<T> current = list.Head;

            while (current != null)
            {
                reversed.AddFirst(current.Value);
                current = current.Next;
            }

            return reversed;
        }

        public static bool AreValidParentheses(string expression)
        {
            var stack = new SinglyLinkedList<char>();

            foreach (char current in expression)
            {
                if (current == '(')
                {
                    stack.AddFirst(current);
                }
                else if (current == ')')
                {
                    if (stack.Head == null)
                    {
                        return false;
                    }
                    else
                    {
                        stack.RemoveFirst();
                    }
                }
            }

            return stack.Head == null;
        }

        public static string RemoveBackspaces(string sequence, char backspace)
        {
            var stack = new SinglyLinkedList<char>();

            foreach (char ch in sequence)
            {
                if (ch == backspace && stack.Head != null)
                {
                    stack.RemoveFirst();
                }
                else if (ch != backspace)
                {
                    stack.AddFirst(ch);
                }
            }

            var sb = new StringBuilder();
            var current = stack.Head;
            while (current != null)
            {
                sb.Insert(0, current.Value);
                current = current.Next;
            }

            return sb.ToString();
        }
    }
}

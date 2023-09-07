using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyLinkedListWorkshop
{
    public class LinkedList<T> : IList<T>
    {
        private Node head;
        private Node tail;

        public LinkedList()
        {
            head = tail = null;
            Count = 0;
        }

        public T Head
        {
            get
            {
                ThrowIfEmpty();
                return head.Value;
            }
        }

        public T Tail
        {
            get
            {
                ThrowIfEmpty();
                return tail.Value;
            }
        }

        public int Count
        {
            get;
            private set;
        }

        public void AddFirst(T value)
        {
            

            // if list is empty
            var newNode = new Node(value); // 3

            if (Count == 0)
            {
                head = tail = newNode;
            }
            else
            {
                // Head -> 5 <-> 7 <- Tail
                // AddFirst(3)
                // Head -> 3 <-> 5 <-> 7 <- Tail
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }

            Count++;
        }

        public void AddLast(T value)
        {
            var newNode = new Node(value);

            if (Count == 0)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Prev = tail;
                tail.Next = newNode;
                tail = newNode;
            }

            Count++;
        }

        public void Add(int index, T value)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            if (index == Count)
            {
                AddLast(value);
                return;
            }

            // 3 5 7 
            // Add(1, 4)
            // 3 4 5 7
            var right = GetNode(index); // 5
            var left = right.Prev; // 3

            var newNode = new Node(value); // 4

            newNode.Prev = left; // 3 <- 4
            left.Next = newNode; // 3 -> 4

            newNode.Next = right; // 4 -> 5
            right.Prev = newNode; // 4 <- 5

            Count++;
        }

        public T Get(int index)
        {
            ThrowIfEmpty();
            /*for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }*/
            var node = GetNode(index);
            return node.Value;
        }

        public int IndexOf(T value)
        {
            int index = 0;
            var current = head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return index;
                }
                index++;
                current = current.Next;
            }

            return -1;
        }

        public T RemoveFirst()
        {
            ThrowIfEmpty();

            // if there is one element
            if (Count == 1)
            {
                return RemoveFromListWithOneElement();
            }

            var result = head.Value;
            head = head.Next;
            head.Prev = null;
            Count--;

            return result;
        }

        public T RemoveLast()
        {
            ThrowIfEmpty();

            if (Count == 1)
            {
                return RemoveFromListWithOneElement();
            }

            var result = tail.Value;
            tail = tail.Prev;
            tail.Next = null;
            Count--;

            return result;
        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
            //return new ListEnumerator(this.head);
        }

        /// <summary>
        /// Enumerates over the linked list values from Head to Tail
        /// </summary>
        /// <returns>A Head to Tail enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ThrowIfEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private T RemoveFromListWithOneElement()
        {
            var result = head.Value;
            head = tail = null;
            Count = 0;
            return result;
        }

        private Node GetNode(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            var current = head;
            while (index > 0)
            {
                current = current.Next;
                index--;
            }

            return current;
        }

        // Use private nested class so that LinkedList users
        // don't know about the LinkedList internal structure
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value
            {
                get;
                private set;
            }

            public Node Next
            {
                get;
                set;
            }

            public Node Prev
            {
                get;
                set;
            }
        }

        // List enumerator that enables traversing all nodes of a list in a foreach loop
        private class ListEnumerator : IEnumerator<T>
        {
            private Node start;
            private Node current;

            internal ListEnumerator(Node head)
            {
                this.start = head;
                this.current = null;
            }

            public T Current
            {
                get
                {
                    if (this.current == null)
                    {
                        throw new InvalidOperationException();
                    }
                    return this.current.Value;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (current == null)
                {
                    current = this.start;
                    return true;
                }

                if (current.Next == null)
                {
                    return false;
                }

                current = current.Next;
                return true;
            }

            public void Reset()
            {
                this.current = null;
            }
        }
    }
}
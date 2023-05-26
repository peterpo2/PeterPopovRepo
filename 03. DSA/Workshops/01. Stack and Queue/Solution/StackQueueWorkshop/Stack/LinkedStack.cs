using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueueWorkshop.Stack
{
    public class LinkedStack<T> : IStack<T>
    {
        private Node<T> top;
        private int size;

        public LinkedStack()
        {
            this.size = 0;
            this.top = null;
        }

        public int Size
        {
            get
            {
                return this.size;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.size == 0;
            }
        }

        public void Push(T element)
        {
            var newNode = new Node<T>();
            newNode.Data = element;
            newNode.Next = top;
            this.top = newNode;
            this.size++;

        }

        public T Pop()
        {
            ValidateNonEmptyList();
            var element = this.top.Data;
            this.top = this.top.Next;
            this.size--;
            return element;

        }

        public T Peek()
        {
            ValidateNonEmptyList();
            var element = this.top.Data;
            return element;
        }

        private void ValidateNonEmptyList()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException();
            }

        }
    }
}

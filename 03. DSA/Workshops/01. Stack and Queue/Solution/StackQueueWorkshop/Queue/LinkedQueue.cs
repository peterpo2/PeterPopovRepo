using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueueWorkshop.Queue
{
    public class LinkedQueue<T> : IQueue<T>
    {
        private Node<T> head, tail;
        private int size;

        public LinkedQueue() 
        {
            this.size = 0;
            this.head = this.tail = null;
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
                return this.Size == 0;
            }
        }

        public void Enqueue(T element)
        {
            var newNode = new Node<T>();
            newNode.Data = element;
            if(this.IsEmpty) 
            {
                this.head=this.tail = newNode;
            }
            else 
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }
            this.size++;
        }

        public T Dequeue()
        {
            ValidateNonEmptyList();
            var element = this.head.Data;
            this.head = this.head.Next;
            this.size--;

            if (this.IsEmpty) 
            {
                this.tail=null;
            }

            return element;
            
        }

        public T Peek()
        {
            ValidateNonEmptyList();
            var element = this.head.Data;
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

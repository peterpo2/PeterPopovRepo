using System;

namespace StackQueueWorkshop.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private int capacity;
        private T[] items;
        private int tail;
        private int head;
        private int size;


        public ArrayQueue() 
        {
            this.head = -1;
            this.tail = -1;
            this.capacity = 8;
            this.size = 0;
            this.items = new T[this.capacity];
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

        public void Enqueue(T element)
        {
            if(this.tail == this.items.Length-1) 
            {
                Resize();
            }
            if (this.IsEmpty)
            {
                this.head = 0;
                this.tail = 0;
            }
            else 
            {
                tail++;
            }
            items[tail] = element;
            this.size++;

        }

        public T Dequeue()
        {
            ValidateNonEmptyArray();

            var element = this.items[this.head];
            this.size--;
            this.head++;
            return element;

        }

        public T Peek()
        {
            ValidateNonEmptyArray();
            var element = this.items[this.head];
            return element;
        }

        private void Resize()
        {
            this.capacity *= 2;
            var newArray = new T[this.capacity];
            Array.Copy(items, newArray, this.items.Length);
            this.items = newArray;
        }
        private void ValidateNonEmptyArray()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException();
            }

        }
    }
}

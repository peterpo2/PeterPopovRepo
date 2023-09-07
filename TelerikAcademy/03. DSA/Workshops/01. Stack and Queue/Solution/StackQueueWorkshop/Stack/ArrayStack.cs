using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueueWorkshop.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        private T[] items;
        private int top;
        private int capacity = 8;
        private int size;

        public ArrayStack() 
        {
            this.items = new T[capacity];
            this.top = -1;
            this.size = 0;
        }

        public int Size
        {
            get
            {
                return this.size;
                //return this.top + 1
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
            //check for size
            if (this.size == this.items.Length)
            //resize
            {
                Resize();
            }
            //add item
            this.top++;
            this.items[this.top] = element;
            this.size++;
        }

        public T Pop()
        {
            ValidateNonEmptyArray();

            var element = this.items[this.top];
            this.top--;
            this.size--;
            return element;
        }

        public T Peek()
        {

            ValidateNonEmptyArray();
            var element = this.items[this.top];
            return element;
        }

        private void Resize() 
        {
            this.capacity *= 2;
            var newArray = new T[this.capacity];
            Array.Copy(items,newArray, this.items.Length);
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

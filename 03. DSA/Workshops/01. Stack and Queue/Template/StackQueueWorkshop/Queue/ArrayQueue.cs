using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueueWorkshop.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private T[] items;
        private int tail;

        public int Size
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsEmpty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Enqueue(T element)
        {
            throw new NotImplementedException();
        }

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }
    }
}

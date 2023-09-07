using System;
using System.Collections.Generic;

namespace BST
{
    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        private T value;
        private IBinarySearchTree<T> left;
        private IBinarySearchTree<T> right;

        public BinarySearchTree(T value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }

        public BinarySearchTree(T value, IBinarySearchTree<T> left, IBinarySearchTree<T> right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public T Value
        {
            get { return this.value; }
        }

        public IBinarySearchTree<T> Left
        {
            get { return this.left; }
        }

        public IBinarySearchTree<T> Right
        {
            get { return this.right; }
        }

        public int Height
        {
            get
            {
                //This code is part of a method that calculates the height of a binary tree. 
                //The first two lines of code check if the left and right nodes of the tree are null. 
                //If they are, the height is set to -1. Otherwise, the height of the left and right nodes are set to the height of the left and right nodes, respectively. 
                //The last line of code returns the height of the tree by adding 1 to the maximum of the left and right heights.
                int leftHeight = left == null ? -1 : left.Height;
                int rightHeight = right == null ? -1 : right.Height;
                return 1 + Math.Max(leftHeight, rightHeight);
            }
        }

        public IList<T> GetInOrder()
        {
            throw new NotImplementedException();
        }

        public IList<T> GetPostOrder()
        {
            throw new NotImplementedException();
        }

        public IList<T> GetPreOrder()
        {
            throw new NotImplementedException();
        }

        public IList<T> GetBFS()
        {
            throw new NotImplementedException();
        }

        public void Insert(T element)
        {
            throw new NotImplementedException();
        }

        public bool Search(T element)
        {
            throw new NotImplementedException();
        }

        // Advanced task!
        //public bool Remove(T value)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

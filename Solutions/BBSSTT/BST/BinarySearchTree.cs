using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BST
{
    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        private T value;
        private BinarySearchTree<T> left;
        private BinarySearchTree<T> right;

        public BinarySearchTree(T value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
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
                int leftHeight = (this.left != null) ? this.left.Height + 1 : 0;
                int rightHeight = (this.right != null) ? this.right.Height + 1 : 0;
                return Math.Max(leftHeight, rightHeight);
            }
        }

        public IList<T> GetInOrder()
        {
            IList<T> result = new List<T>();
            if (left != null)
            {
                result = left.GetInOrder();
            }
            result.Add(value);
            if (right != null)
            {
                result = result.Concat(right.GetInOrder()).ToList();
            }
            return result;
        }

        public IList<T> GetPostOrder()
        {
            IList<T> result = new List<T>();
            if (left != null)
            {
                result = left.GetPostOrder();
            }
            if (right != null)
            {
                result = result.Concat(right.GetPostOrder()).ToList();
            }
            result.Add(value);
            return result;
        }

        public IList<T> GetPreOrder()
        {
            IList<T> result = new List<T>();
            result.Add(value);
            if (left != null)
            {
                result = result.Concat(left.GetPreOrder()).ToList();
            }
            if (right != null)
            {
                result = result.Concat(right.GetPreOrder()).ToList();
            }
            return result;
        }

        public IList<T> GetBFS()
        {
            IList<T> result = new List<T>();
            Queue<BinarySearchTree<T>> queue = new Queue<BinarySearchTree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                BinarySearchTree<T> node = queue.Dequeue();
                result.Add(node.value);
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            return result;
        }

        public void Insert(T element)
        {
            if (element.CompareTo(value) < 0)
            {
                if (left == null)
                {
                    left = new BinarySearchTree<T>(element);
                }
                else
                {
                    left.Insert(element);
                }
            }
            else if (element.CompareTo(value) > 0)
            {
                if (right == null)
                {
                    right = new BinarySearchTree<T>(element);
                }
                else
                {
                    right.Insert(element);
                }
            }
        }

        public bool Search(T element)
        {
            if (element.CompareTo(this.value) == 0)
            {
                return true;
            }
            else if (element.CompareTo(this.value) < 0)
            {
                return (this.left != null) && this.left.Search(element);
            }
            else
            {
                return (this.right != null) && this.right.Search(element);
            }
        }

        // Advanced task!
        public bool Remove(T value)
        {
            BinarySearchTree<T> parent = null;
            BinarySearchTree<T> current = this;

            while (current != null && current.value.CompareTo(value) != 0)
            {
                parent = current;

                if (value.CompareTo(current.value) < 0)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }

            if (current == null)
            {
                return false;
            }

            if (current.left == null && current.right == null)
            {
                if (current != this)
                {
                    if (parent.left == current)
                    {
                        parent.left = null;
                    }
                    else
                    {
                        parent.right = null;
                    }
                }
                else
                {
                    this.value = default(T);
                }
            }
            else if (current.left == null)
            {
                if (current != this)
                {
                    if (parent.left == current)
                    {
                        parent.left = current.right;
                    }
                    else
                    {
                        parent.right = current.right;
                    }
                }
                else
                {
                    this.value = current.right.value;
                    this.left = current.right.left;
                    this.right = current.right.right;
                }
            }
            else if (current.right == null)
            {
                if (current != this)
                {
                    if (parent.left == current)
                    {
                        parent.left = current.left;
                    }
                    else
                    {
                        parent.right = current.left;
                    }
                }
                else
                {
                    this.value = current.left.value;
                    this.right = current.left.right;
                    this.left = current.left.left;
                }
            }
            else
            {
                BinarySearchTree<T> smallestParent = current;
                BinarySearchTree<T> smallest = current.right;

                while (smallest.left != null)
                {
                    smallestParent = smallest;
                    smallest = smallest.left;
                }

                if (smallestParent.left == smallest)
                {
                    smallestParent.left = smallest.right;
                }
                else
                {
                    smallestParent.right = smallest.right;
                }

                current.value = smallest.value;
            }

            return true;
        }
    }
}

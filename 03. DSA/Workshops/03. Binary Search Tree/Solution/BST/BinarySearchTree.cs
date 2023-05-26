using System;
using System.Collections.Generic;

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
            get
            {
                return value;
            }
            private set
            {
                this.value = value;
            }
        }

        public IBinarySearchTree<T> Left
        {
            get
            {
                return this.left;
            }
        }

        public IBinarySearchTree<T> Right
        {
            get
            {
                return this.right;
            }
        }

        public int Height
        {
            get
            {
                int leftHeight = this.left != null ? this.left.Height + 1 : 0;
                int rightHeight = this.right != null ? this.right.Height + 1 : 0;

                return Math.Max(leftHeight, rightHeight);
            }
        }

        public IList<T> GetInOrder()
        {
            var result = new List<T>();

            //GetInOrderHelper(result, this);

            if (this.left != null)
            {
                result.AddRange(this.left.GetInOrder());
            }

            result.Add(this.Value);

            if (this.right != null)
            {
                result.AddRange(this.right.GetInOrder());
            }

            return result;
        }

        private void GetInOrderHelper(IList<T> list, BinarySearchTree<T> node)
        {
            if (node != null)
            {
                GetInOrderHelper(list, node.left);
                list.Add(node.Value);
                GetInOrderHelper(list, node.right);
            }
        }

        public IList<T> GetPostOrder()
        {
            var result = new List<T>();

            if (this.left != null)
            {
                result.AddRange(this.left.GetPostOrder());
            }

            if (this.right != null)
            {
                result.AddRange(this.right.GetPostOrder());
            }

            result.Add(this.Value);

            return result;
        }

        public IList<T> GetPreOrder()
        {
            var result = new List<T>();

            result.Add(this.Value);

            if (this.left != null)
            {
                result.AddRange(this.left.GetPreOrder());
            }

            if (this.right != null)
            {
                result.AddRange(this.right.GetPreOrder());
            }

            return result;
        }

        public IList<T> GetBFS()
        {
            var result = new List<T>();
            var queue = new Queue<BinarySearchTree<T>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Add(current.Value);

                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }
            }

            return result;
        }

        public void Insert(T newValue)
        {
            if (this.Value.CompareTo(newValue) == 0)
            {
                throw new ArgumentException($"{newValue} already exists.");
            }

            if (this.Value.CompareTo(newValue) > 0)
            {
                if (this.left == null)
                {
                    this.left = new BinarySearchTree<T>(newValue);
                }
                else
                {
                    this.left.Insert(newValue);
                }
            }

            if (this.Value.CompareTo(newValue) < 0)
            {
                if (this.right == null)
                {
                    this.right = new BinarySearchTree<T>(newValue);
                }
                else
                {
                    this.right.Insert(newValue);
                }
            }
        }

        public bool Search(T element)
        {
            if (this.Value.CompareTo(element) == 0)
            {
                return true;
            }

            if (this.left != null && this.Value.CompareTo(element) > 0)
            {
                return this.left.Search(element);
            }

            if (this.right != null && this.Value.CompareTo(element) < 0)
            {
                return this.right.Search(element);
            }

            return false;
        }

        // ADVANCED TASK!
        public bool Remove(T valueToRemove)
        {
            return RemoveNode(this, valueToRemove);
        }

        private bool RemoveNode(BinarySearchTree<T> root, T valueToRemove)
        {
            // value to remove is found
            if (this.Value.CompareTo(valueToRemove) == 0)
            {
                // get the node to remove and its parent node
                var nodeToRemove = GetNode(valueToRemove);
                var parent = GetParent(root, nodeToRemove);

                // 1. if node to remove is a leaf node
                // just set parent node's reference to null
                if (nodeToRemove.left == null && nodeToRemove.right == null)
                {
                    if (parent.left == nodeToRemove)
                    {
                        parent.left = null;
                    }
                    else
                    {
                        parent.right = null;
                    }
                }
                // 2. if node to remove has 1 child
                // 2.1 node to remove has a right child
                else if (nodeToRemove.left == null)
                {
                    if (parent.left == nodeToRemove)
                    {
                        parent.left = nodeToRemove.right;
                    }
                    else
                    {
                        parent.right = nodeToRemove.right;
                    }
                }
                // 2.2 node to remove has a left child
                else if (nodeToRemove.right == null)
                {
                    if (parent.left == nodeToRemove)
                    {
                        parent.left = nodeToRemove.left;
                    }
                    else
                    {
                        parent.right = nodeToRemove.left;
                    }
                }
                // 3. node to remove has 2 children
                else
                {
                    // get the node with max value from left subtree
                    var maxNodeInLeftSubtree = GetMaxValueNode(nodeToRemove.left);
                    // remove the max value node from the left subtree
                    this.left.RemoveNode(this, maxNodeInLeftSubtree.Value);
                    // assign the stored max value in place of the node to remove
                    nodeToRemove.Value = maxNodeInLeftSubtree.Value;
                }
                return true;
            }
            // node to remove is in the left subtree
            if (this.left != null && this.Value.CompareTo(valueToRemove) > 0)
            {
                return this.left.RemoveNode(root, valueToRemove);
            }
            // node to remove is in the right subtree
            else if (this.right != null && this.Value.CompareTo(valueToRemove) < 0)
            {
                return this.right.RemoveNode(root, valueToRemove);
            }

            return false;
        }

        /// <summary>
        /// Returns a node by value, assumes value is present in the tree
        /// </summary>
        private BinarySearchTree<T> GetNode(T value)
        {
            if (this.Value.CompareTo(value) == 0)
            {
                return this;
            }

            if (this.left != null && this.Value.CompareTo(value) > 0)
            {
                return this.left.GetNode(value);
            }

            return this.right.GetNode(value);
        }

        /// <summary>
        /// Returns parent node of a given node, starting from a given root
        /// </summary>
        private BinarySearchTree<T> GetParent(BinarySearchTree<T> root, BinarySearchTree<T> node)
        {
            // root doesn't have parent, so we just return it
            if (root == node)
            {
                return root;
            }

            if (root.left == node || root.right == node)
            {
                return root;
            }

            if (root.left != null && root.Value.CompareTo(node.Value) > 0)
            {
                return root.left.GetParent(root.left, node);
            }

            return root.right.GetParent(root.right, node);
        }

        private BinarySearchTree<T> GetMaxValueNode(BinarySearchTree<T> root)
        {
            while (root.right != null)
            {
                root = root.right;
            }

            return root;
        }

        public override string ToString()
        {
            return $"{Value} ";
        }
    }
}

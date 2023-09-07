using System;
using System.Collections;
using System.Collections.Generic;

namespace TreesSessionDemoA47
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*var root = new TreeNode(6);
            root.Children.Add(new TreeNode(5));
            root.Children.Add(new TreeNode(4));
            root.Children.Add(new TreeNode(2));

            root.Children[0].Children.Add(new TreeNode(8));
            root.Children[0].Children.Add(new TreeNode(9));
            root.Children[0].Children.Add(new TreeNode(3));

            root.Children[2].Children.Add(new TreeNode(1));
            root.Children[2].Children.Add(new TreeNode(7));

            Console.WriteLine("Breadth-First Traversal:");
            BFS(root);
            Console.WriteLine();
            Console.WriteLine("DFS with stack:");
            DFS(root);
            Console.WriteLine();
            Console.WriteLine("DFS with stack, reversed:");
            DFSReversed(root);
            Console.WriteLine();
            Console.WriteLine("DFS recursive:");
            DFSRecursive(root);*/

            var root = new BinaryTreeNode(6);
            root.Left = new BinaryTreeNode(5);
            root.Right = new BinaryTreeNode(2);

            root.Left.Left = new BinaryTreeNode(8);
            root.Left.Right = new BinaryTreeNode(3);

            root.Right.Left = new BinaryTreeNode(1);
            root.Right.Right = new BinaryTreeNode(7);

            Console.WriteLine("Pre oder: ");
            PreOrder(root);
            Console.WriteLine();
            Console.WriteLine("In order: ");
            InOrder(root);
            Console.WriteLine();
            Console.WriteLine("Post order: ");
            PostOrder(root);
        }

        static void PostOrder(BinaryTreeNode root)
        {
            if (root.Left != null)
            {
                PostOrder(root.Left);
            }

            if (root.Right != null)
            {
                PostOrder(root.Right);
            }

            Console.Write($"{root.Value} ");
        }

        static void InOrder(BinaryTreeNode root)
        {
            if (root.Left != null)
            {
                InOrder(root.Left);
            }

            Console.Write($"{root.Value} ");

            if (root.Right != null)
            {
                InOrder(root.Right);
            }
        } 

        static void PreOrder(BinaryTreeNode root)
        {
            Console.Write($"{root.Value} ");

            if (root.Left != null)
            {
                PreOrder(root.Left);
            }

            if (root.Right != null)
            {
                PreOrder(root.Right);
            }
        }

        static void DFSRecursive(TreeNode root)
        {
            Console.Write($"{root.Value} ");

            for (int i = root.Children.Count - 1; i >= 0; i--)
            {
                DFSRecursive(root.Children[i]);
            }
        }

        static void DFSReversed(TreeNode root)
        {
            var stack = new Stack<TreeNode>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                var element = stack.Pop();

                Console.Write($"{element.Value} ");

                for (int i = element.Children.Count - 1; i >= 0; i--)
                {
                    stack.Push(element.Children[i]);
                }
            }
        }

        static void DFS(TreeNode root)
        {
            var stack = new Stack<TreeNode>();

            stack.Push(root);

            while (stack.Count > 0)
            {
                var element = stack.Pop();

                Console.Write($"{element.Value} ");

                foreach (var child in element.Children)
                {
                    stack.Push(child);
                }
            }
        }

        static void BFS(TreeNode root)
        {
            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                var element = queue.Dequeue();

                Console.Write($"{element.Value} ");

                foreach (var child in element.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }
    }
}
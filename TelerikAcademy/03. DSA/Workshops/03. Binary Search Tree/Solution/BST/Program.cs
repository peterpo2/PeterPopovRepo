using BST;
using System;

namespace BinarySearchTree
{
	class Program
	{
		static void Main(string[] args)
		{
            BinarySearchTree<int> testTree = new BinarySearchTree<int>(50);
            testTree.Insert(30);
            testTree.Insert(20);
            testTree.Insert(40);
            testTree.Insert(70);
            testTree.Insert(60);
            testTree.Insert(80);
            testTree.Insert(72);
            testTree.Insert(71);

            // best to use In-order traversal, as it prints nodes in sorted order
            // uncomment the code snippets below to test

            //testTree.Insert(39);
            //Console.WriteLine(string.Join(" ", testTree.GetInOrder()));
            //testTree.Remove(50);
            //Console.WriteLine(string.Join(" ", testTree.GetInOrder()));

            //Console.WriteLine(string.Join(" ", testTree.GetInOrder()));
            //testTree.Remove(70);
            //Console.WriteLine(string.Join(" ", testTree.GetInOrder()));
        }
    }
}

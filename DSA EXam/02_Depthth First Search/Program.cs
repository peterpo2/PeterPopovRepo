namespace _02_Depthth_First_Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var root = new Node(6);
            root.Left = new Node(5);
            root.Right = new Node(2);
            root.Left.Left = new Node(8);
            root.Left.Right = new Node(3);
            root.Right.Left = new Node(1);
            root.Right.Right = new Node(7);

            Console.WriteLine("PreOrderTraversal");
            PreOrderTraversal(root);
            Console.WriteLine($"\nInOrderTraversal");
            InOrderTraversal(root);
            Console.WriteLine($"\nPostOrderTraversal");
            PostOrderTraversal(root);

        }
        //           6
        //         /   \
        //       5       2
        //      / \     / \
        //     8   3   1   7

        class Node
        {
            public Node(int value)
            {
                this.Value = value;
            }
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }
        private static void PreOrderTraversal(Node node)
        {
            if (node != null)
            {
                Console.Write(node.Value + " "); // Process the current node
                PreOrderTraversal(node.Left);   // Recur on the left subtree
                PreOrderTraversal(node.Right);  // Recur on the right subtree
            }
        }

        private static void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);   // Recur on the left subtree
                Console.Write(node.Value + " "); // Process the current node
                InOrderTraversal(node.Right);  // Recur on the right subtree
            }
        }

        private static void PostOrderTraversal(Node node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left);   // Recur on the left subtree
                PostOrderTraversal(node.Right);  // Recur on the right subtree
                Console.Write(node.Value + " "); // Process the current node
            }
        }
    }
}
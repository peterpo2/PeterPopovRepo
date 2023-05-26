namespace _10_Tree
{
    public class Program
    {
        public class Node
        {
            public Node(int value)
            {
                this.Value = value;
            }
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }
        static void Main(string[] args)
        {
            var root = new Node(5);
            root.Left = new Node(3);
            root.Right = new Node(7);
            root.Left.Left = new Node(2);
            root.Left.Right = new Node(4);
            root.Right.Left = new Node(6);
            root.Right.Right = new Node(8);

            Method(root);
            //Returns only leaf elements
        }

        public static void Method(Node root)
        {
            if (root.Left == null && root.Right == null)
            {
                Console.WriteLine(root.Value);
            }
            if (root.Left != null)
            {
                Method(root.Left);
            }
            if (root.Right != null)
            {
                Method(root.Right);
            }
        }
    }
}
using System.Security.Claims;

namespace _04_Foo_Method_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Node leaf1 = new Node(8, null, null);
            Node leaf2 = new Node(3, null, null);
            Node leaf3 = new Node(1, null, null);
            Node leaf4 = new Node(7, null, null);
            Node node1 = new Node(5, leaf1, leaf2);
            Node node2 = new Node(2, leaf3, leaf4);
            Node root = new Node(6, node1, node2);

            //           6
            //         /   \
            //       5       2
            //      / \     / \
            //     8   3   1   7

            root.Foo();

            // Returns only leaf elements in a tree

        }
    }
    public class Node
    {
        int value;
        Node left, right;

        public Node(int value, Node left, Node right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public IEnumerable<int> Foo()
        {
            var list = new List<int>();
            if (this.left == null && this.right == null)
            {
                Console.WriteLine($"Null: {value}");
                list.Add(this.value);
            }

            if (this.left != null)
            {
                Console.WriteLine($"Left != null: {value}");
                list.AddRange(this.left.Foo());
            }

            if (this.right != null)
            {
                Console.WriteLine($"Right != null: {value}");
                list.AddRange(this.right.Foo());
            }

            Console.WriteLine(string.Join(" ", list));
            return list;
        }
    }
}
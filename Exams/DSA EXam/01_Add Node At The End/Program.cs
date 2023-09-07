namespace _01_Add_Node_At_The_End
{
     class Program
    {
        static void Main(string[] args)
        {
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);
            Node n6 = new Node(6);
            Node n7 = new Node(7);
            Node n8 = new Node(8);
            n1.Next = n3;
            n2.Next = n4;
            n3.Next = n5;
            n4.Next = n6;
            n5.Next = n7;
            n6.Next = n8;

            Method(n1, n2);
            Node current = n1;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
        private static Node Method(Node n1, Node n2)
        {
            Node current = n1;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = n2;

            return n1;
        }
    }

    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }
        public int Value { get; set; }
        public Node Next { get; set; }
    }
}
using System.Transactions;

namespace DetectLinkedListCycle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node list = InitList();
            Console.WriteLine(DetectCycleHashSet(list));

        }

        static bool DetectCycleHashSet(Node head) 
        {
            var set = new HashSet<Node>();

            Node current = head;

            while(current != null) 
            {
                if (!set.Add(current)) 
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        static bool DetectCycle(Node head) 
        {
            Node slow = head;
            Node fast = head;

            while (fast.Next != null) 
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast) 
                {
                    return true;
                }
            }

            return false;
        
        }


        static void Print(Node node) 
        {
            Node current = node;
            while (current != null) 
            {
                Console.Write($"{current.Value} - >");
                current = current.Next;
            }
        }

        static Node InitList() 
        {
            Node head = new Node(1);
            Node current = head;
            for (int i = 2; i <= 6; i++) 
            {
                current.Next = new Node(i);
                current = current.Next;
            }
            //current.Next = head;

            return head;
        }

        public class Node
        {
            public Node(int value) 
            {
                this.Value = value;
            }
            public int Value
            {
                get;
                set;
            }
            public Node Next
            {
                get;
                set;
            }
        }

    }
}